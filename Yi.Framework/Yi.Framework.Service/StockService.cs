using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Common.Const;
using Yi.Framework.Core;
using Yi.Framework.DTOModel;
using Yi.Framework.Interface;

namespace Yi.Framework.Service
{
    public partial class StockService: IStockService
    {
             
        /// <summary>
        /// 恢复库存，以订单为单位
        /// </summary>
        /// <param name="spu"></param>
        public void ResumeStock(CartDto cartDtos, long orderId, object _cacheClientDB)
        {
           CacheClientDB cacheClientDB =(CacheClientDB)_cacheClientDB;
            IDbContextTransaction trans = null;
            try
            {
                trans = _Db.Database.BeginTransaction();
      
              
                    int count = _Db.Database.ExecuteSqlRaw($"update tb_stock set stock = stock + {cartDtos.num} where sku_id = {cartDtos.skuId}");
                    if (count != 1)
                    {
                        throw new Exception("恢复库存失败");
                    }
              
                trans.Commit();

                    
                    #region 增加Redis库存
                    string key = $"{RedisConst.keyOrden}{cartDtos.skuId}";
                    cacheClientDB.IncrementValueBy(key, cartDtos.num);
                    #endregion
           

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
        }

        /// <summary>
        /// 减少库存
        /// </summary>
        /// <param name="cartDtos"></param>
        public void DecreaseStock(CartDto cartDtos, long orderId)
        {
            IDbContextTransaction trans = null;
            try
            {

                trans = _Db.Database.BeginTransaction();

                    int count = _Db.Database.ExecuteSqlRaw($"update tb_stock set stock = stock - {cartDtos.num} where sku_id = {cartDtos.skuId} and stock >= {cartDtos.num}");
                    if (count != 1)
                    {
                        throw new Exception("扣减库存失败");
                    }

                _Db.SaveChanges();
                trans.Commit();
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
        }

       
    }
}
