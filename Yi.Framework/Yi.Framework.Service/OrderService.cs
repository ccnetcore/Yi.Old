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
        private  ICapPublisher _iCapPublisher;
        private CacheClientDB _cacheClientDB;
        private RabbitMQInvoker _rabbitMQInvoker;
        private readonly ILogger<OrderService> _logger;
        public OrderService(ICapPublisher iCapPublisher, ILogger<OrderService> logger, CacheClientDB cacheClientDB ,RabbitMQInvoker rabbitMQInvoker,IDbContextFactory db):base(db)
        {
            _iCapPublisher = iCapPublisher;
            _cacheClientDB = cacheClientDB; 
            _rabbitMQInvoker = rabbitMQInvoker; 
            _logger = logger;   
        }
        public async Task< order> CreateOrder(OrderDto orderDto)
        {
            order _order=new();         
            _order.id =(int) Common.Helper.StringHelper.GetGuidToLongID();
            _order.creat_time = DateTime.Now; 
            _order.sku =await _DbRead.Set<sku>().FindAsync( (int)orderDto.carts.skuId);

            await AddAsync(_order);
            IDbContextTransaction trans = null;
            try
            {
                #region 数据库拆分后--分布式事务--减少库存
                trans = _Db.Database.BeginTransaction(_iCapPublisher, autoCommit: false);
                this._iCapPublisher.Publish(name: RabbitConst.Order_Stock_Decrease_Queue,
                    contentObj: new OrderCartDto()
                    {
                        Carts= orderDto.carts,
                        OrderId= _order.id

                    }, headers: null);
                this._Db.SaveChanges();             
                
                    string key = $"{RedisConst.keyOrden}:{orderDto.carts.skuId}";
                    if (!this._cacheClientDB.ContainsKey(key))
                    {
                        throw new Exception("库存在Redis不存在,需要初始化");
                    }
                    else if (this._cacheClientDB.DecrementValueBy(key, orderDto.carts.num) < 0)
                    {
                        this._cacheClientDB.IncrementValueBy(key, orderDto.carts.num);//订单失败恢复回去
                        throw new Exception("库存在Redis不足,需要检查");
                    }
                    ////需要多项同时减少，支持多key，需要Lua TODO
              
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
                    this._rabbitMQInvoker.SendDelay(RabbitConst.OrderCreate_Delay_Exchange, message,10*60);

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


        public async Task<bool> CloseOrder(int orderId)
        {
            var skuIdList =await this._Db.Set<order>().Where(od => od.id == orderId).Include(u=>u.sku). Select(od => new
            {
                skuId = od.sku.id,
                num = od.num
            }).ToListAsync();

            IDbContextTransaction trans = null;
            try
            {
                #region 数据库拆分后--分布式事务
                trans = this._Db.Database.BeginTransaction(this._iCapPublisher, autoCommit: false);
                this._iCapPublisher.Publish(name: RabbitConst.Order_Stock_Resume_Queue,
                    contentObj: new OrderCartDto()
                    {
                        Carts = skuIdList.Select(sku => new CartDto()
                        {
                            skuId = sku.skuId,
                            num = sku.num
                        }).ToList(),
                        OrderId = orderId
                    }, headers: null);
                this._Db.SaveChanges();
                Console.WriteLine("数据库业务数据已经插入,操作完成");
                trans.Commit();
                #endregion
            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                    Console.WriteLine(ex.ToString());
                }
                throw;
            }
            finally
            {
                trans.Dispose();
            }
            return true;
        }
    }
}
