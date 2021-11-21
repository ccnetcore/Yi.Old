using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Yi.Framework.Common.Const;
using Yi.Framework.DTOModel;

namespace Yi.Framework.StockMicroservice.Controllers
{
    public class StockController : Controller
    {
        private readonly ICapPublisher _iCapPublisher;
        private ILogger<StockController> _Logger;
        public StockController(ICapPublisher capPublisher, ILogger<StockController> logger)
        {
            _logger = logger;
            _iCapPublisher = capPublisher;
        }
         
        #region 下单减库存
        [NonAction]
        [CapSubscribe(RabbitConst.Order_Stock_Decrease_Queue)]
        public void DecreaseStockByOrder(OrderCartDto orderCartDto, [FromCap] CapHeader header)
        {
            try
            {
                Console.WriteLine($@"{DateTime.Now} DecreaseStockByOrder invoked, Info: {Common.Helper.JsonHelper.ObjToStr(orderCartDto)}");
                using (var trans = this._DB.Database.BeginTransaction(this._iCapPublisher, autoCommit: false))
                {
                    this._iStockService.DecreaseStock(orderCartDto.Carts, orderCartDto.OrderId);;
                    this._DB.SaveChanges();
                    Console.WriteLine("数据库业务数据已经插入,操作完成");
                    trans.Commit();
                }
                this._Logger.LogWarning($"This is EFCoreTransaction Invoke");
            }
            catch (Exception ex)
            {
                Console.WriteLine("****************************************************");
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

        #region 取消订单恢复库存
        [NonAction]
        [CapSubscribe(RabbitConst.Order_Stock_Resume_Queue)]
        public void ResumeStockByOrder(OrderCartDto orderCartDto, [FromCap] CapHeader header)
        {
            try
            {
                Console.WriteLine($@"{DateTime.Now} ResumeStockByOrder invoked, Info: {Common.Helper.JsonHelper.ObjToStr(orderCartDto)}");
                this._iStockService.ResumeStock(orderCartDto.Carts, orderCartDto.OrderId);
                Console.WriteLine("数据库业务数据已经插入,操作完成");
            }
            catch (Exception ex)
            {
                Console.WriteLine("****************************************************");
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion
    }
}
