using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Common.Const;
using Yi.Framework.Core;
using Yi.Framework.DTOModel;
using Yi.Framework.Interface;
using Yi.Framework.Model.ModelFactory;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Service
{
    public partial class OrderService:BaseService<order>,IOrderService
    {
        private IGoodsService _goodsService;
        private  ICapPublisher _iCapPublisher;
        private CacheClientDB _cacheClientDB;
        private RabbitMQInvoker _rabbitMQInvoker;
        private readonly ILogger<OrderService> _logger;
        public OrderService(ILogger<OrderService> logger, CacheClientDB cacheClientDB ,RabbitMQInvoker rabbitMQInvoker  ,IGoodsService goodsService,IDbContextFactory db):base(db)
        {
            _goodsService = goodsService;
            _cacheClientDB = cacheClientDB; 
            _rabbitMQInvoker = rabbitMQInvoker; 
            _logger = logger;   
        }
        public async Task<order> CreateOrder(OrderDto orderDto, user _user)
        {
            order _order=new();
           
            _order.id =(int) Common.Helper.StringHelper.GetGuidToLongID();
            _order.creat_time = DateTime.Now;
            Dictionary<long, int> car = orderDto.carts.ToDictionary(u => u.skuId, u => u.num);
            List<sku> skus=_goodsService.QuerySkuByIds(car.Keys.ToList());
            if (skus.Count <= 0)
            {
                throw new Exception("查询的商品信息不存在");
            }
           
            _order.sku = skus[0];

            await AddAsync(_order);
            IDbContextTransaction trans = null;

            try
            {
                #region 数据库拆分后--分布式事务
                trans = _Db.Database.BeginTransaction(this._iCapPublisher, autoCommit: false);
                this._iCapPublisher.Publish(name: RabbitConst.Order_Stock_Decrease_Queue,
                    contentObj: new OrderCartDto()
                    {
                        Carts= orderDto.carts,
                        OrderId= _order.id

                    }, headers: null);
                this._Db.SaveChanges();
                foreach (var skuIdNum in car)
                {
                    string key = $"{RedisConst.keyOrden}{skuIdNum.Key}";
                    if (!this._cacheClientDB.ContainsKey(key))
                    {
                        throw new Exception("库存在Redis不存在,需要初始化");
                    }
                    else if (this._cacheClientDB.DecrementValueBy(key, skuIdNum.Value) < 0)
                    {
                        this._cacheClientDB.IncrementValueBy(key, skuIdNum.Value);//订单失败恢复回去
                        throw new Exception("库存在Redis不足,需要检查");
                    }
                    ////需要多项同时减少，支持多key，需要Lua TODO
                }
                trans.Commit();
                Console.WriteLine("数据库业务数据已经插入,操作完成");
            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    Console.WriteLine(ex);
                    trans.Rollback();
                }
                throw;
            }
            finally
            {
                trans.Dispose();
            }

         
            {

                try
                {
                    var orderCreateQueueModel = new OrderCartDto()
                    {
                        Carts = orderDto.carts,
                        OrderId = _order.id
                    };
                    string message = Common.Helper.JsonHelper.ObjToStr(orderCreateQueueModel);
               

                    //this._RabbitMQInvoker.SendDelay(RabbitMQExchangeQueueName.OrderCreate_Delay_Exchange, message, 60 * 30);
                    //发布延时关闭订单任务
                    this._rabbitMQInvoker.SendDelay(RabbitConst.OrderCreate_Delay_Exchange, message, 30);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    this._logger.LogError($"消息失败，OrderId={_order.id}");
                }
            }
            #endregion


            return _order;
        }       
    }
}
