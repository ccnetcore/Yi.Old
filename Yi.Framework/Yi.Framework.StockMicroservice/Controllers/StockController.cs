using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using Yi.Framework.Common.Const;
using Yi.Framework.Core;
using Yi.Framework.DTOModel;
using Yi.Framework.Interface;

namespace Yi.Framework.StockMicroservice.Controllers
{
    public class StockController : Controller
    {
        private readonly ICapPublisher _iCapPublisher;
        private readonly ILogger<StockController> _logger;
        private IStockService _stockService;
        private CacheClientDB _cacheClientDB;
        private DbContext _db;
        public StockController(ICapPublisher capPublisher, ILogger<StockController> logger, IStockService stockService, CacheClientDB cacheClientDB,DbContext db)
        {
            _stockService = stockService;
            _logger = logger;
            _iCapPublisher = capPublisher;
            _cacheClientDB = cacheClientDB;
            _db = db;
        }
         
        #region 下单减库存
        [NonAction]
        [CapSubscribe(RabbitConst.Order_Stock_Decrease_Queue)]
        public void DecreaseStockByOrder(OrderCartDto orderCartDto, [FromCap] CapHeader header)
        {
            try
            {
                Console.WriteLine($@"{DateTime.Now} DecreaseStockByOrder invoked, Info: {Common.Helper.JsonHelper.ObjToStr(orderCartDto)}");
                using (var trans = _db.Database.BeginTransaction(this._iCapPublisher, autoCommit: false))
                {
                   _stockService.DecreaseStock(orderCartDto.Carts, orderCartDto.OrderId);
                    Console.WriteLine("数据库业务数据已经插入,操作完成");
                    trans.Commit();
                }
                _logger.LogWarning($"This is EFCoreTransaction Invoke");
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
                _stockService.ResumeStock(orderCartDto.Carts, orderCartDto.OrderId, _cacheClientDB);
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
