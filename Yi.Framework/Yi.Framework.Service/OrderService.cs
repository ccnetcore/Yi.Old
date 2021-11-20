using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.DTOModel;
using Yi.Framework.Interface;
using Yi.Framework.Model.ModelFactory;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Service
{
    public partial class OrderService:BaseService<order>,IOrderService
    {
        private IGoodsService _goodsService;
        public OrderService(IGoodsService goodsService,IDbContextFactory db):base(db)
        {
            _goodsService = goodsService;
        }
        public async Task<order> CreateOrder(OrderDto orderDto, user _user)
        {
            order _order=new();
            _order.buyer_message = "无";
            _order.buyer_nick = _user.nick;
            _order.buyer_rate = 0;
            _order.source_type = 1;
            _order.shipping_name = "京东";
            _order.shipping_code = "jd123456";
            _order.receiver_zip="330200";
            _order.receiver_state = "江西省";
            _order.receiver_mobile = _user.phone;
            _order.receiver_district = "南昌县";
            _order.receiver_city = "南昌市";
            _order.receiver_address = orderDto.addressId;
            _order.receiver = _user.username;
            _order.promotion_ids = null;
            _order.post_fee = 0;
            _order.payment_type = orderDto.paymentType;
            _order.is_delete = (short)Common.Enum.DelFlagEnum.Normal;
            _order.invoice_type = 1;
            _order.id = Common.Helper.StringHelper.GetGuidToLongID().ToString();
            _order.creat_time = DateTime.Now;
            Dictionary<long, int> car = orderDto.carts.ToDictionary(u => u.skuId, u => u.num);
            List<sku> skus=_goodsService.QuerySkuByIds(car.Keys.ToList());
            if (skus.Count <= 0)
            {
                throw new Exception("查询的商品信息不存在");
            }
            double pay=0;
            skus.ForEach(u => pay+=u.price);
            _order.total_pay = pay;
            _order.actual_pay = pay;
            _order.sku = skus[0];

            await AddAsync(_order);
            IDbContextTransaction trans = null;


            try
            {
                #region 数据库拆分后--分布式事务
                trans = _DbFactory.ConnWriteOrRead(Common.Enum.WriteAndReadEnum.Write).Database.BeginTransaction(this._iCapPublisher, autoCommit: false);
                this._iCapPublisher.Publish(name: RabbitMQExchangeQueueName.Order_Stock_Decrease,
                    contentObj: new OrderCartDto()
                    {
                        Carts = orderDto.carts,
                        OrderId = order.OrderId
                    }, headers: null);
                this._orangeContext.SaveChanges();
                foreach (var skuIdNum in car)
                {
                    string key = $"{Common.Const.RedisConst.keyOrden}";
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




            #region 异步清理购物车+延时取消任务+确认订单支付状态任务
            {
                //删除购物车中已经下单的商品数据, 采用异步mq的方式通知购物车系统删除已购买的商品，传送商品ID和用户ID---模拟操作失败
                try
                {
                    var orderCreateQueueModel = new OrderCreateQueueModel()
                    {
                        OrderId = order.OrderId,
                        UserId = userInfo.id,
                        SkuIdList = skuNumMap.Keys.ToList(),
                        TryTime = 0,
                        OrderType = OrderCreateQueueModel.OrderTypeEnum.Normal
                    };
                    string message = JsonConvert.SerializeObject(orderCreateQueueModel);
                    //发布清理购物车任务
                    this._RabbitMQInvoker.Send(new RabbitMQConsumerModel() { ExchangeName = RabbitMQExchangeQueueName.OrderCreate_Exchange, QueueName = RabbitMQExchangeQueueName.OrderCreate_Queue_CleanCart }, message);

                    //this._RabbitMQInvoker.SendDelay(RabbitMQExchangeQueueName.OrderCreate_Delay_Exchange, message, 60 * 30);
                    //发布延时关闭订单任务
                    this._RabbitMQInvoker.SendDelay(RabbitMQExchangeQueueName.OrderCreate_Delay_Exchange, message, 30);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    this._logger.LogError($"发送异步购物车清理消息失败，OrderId={order.OrderId}，UserId={userInfo.id}");
                }
            }
            #endregion



            return _order;
        }
    }
}
