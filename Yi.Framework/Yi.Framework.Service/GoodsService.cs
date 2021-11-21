using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Core;
using Yi.Framework.Interface;
using Yi.Framework.Model.ModelFactory;
using Yi.Framework.Model.Models;
using Yi.Framework.Model.Search;

namespace Yi.Framework.Service
{
    public class GoodsService :BaseService<spu>,  IGoodsService
    {
        short Normal = (short)Common.Enum.DelFlagEnum.Normal;
        public GoodsService(IDbContextFactory DbFactory) : base(DbFactory)
        {
            _DbFactory = DbFactory;
        }

        public Goods GetGoodsBySpuId(int spuId)
        {
            var _spu = _DbRead.Set<spu>().Include(u => u.skus).Where(u => u.id == spuId).FirstOrDefault();
           return GoodsBuild.BuildGoods(_spu, this);
        }

        public PageResult<spu> QuerySpuByPage(int page, int rows)
        {
            var spuList = _DbRead.Set<spu>().Include(u => u.skus).Where(u => u.is_delete == Normal).OrderByDescending(u => u.crate_time).Skip((page - 1) * rows).Take(rows).ToList();
            var totalPages = spuList.Count % 2 == 0 ? spuList.Count / rows : spuList.Count / rows + 1;
            
            return new PageResult<spu>() { rows = spuList, total = spuList.Count, totalPages = totalPages };
        }

        public List<sku> QuerySkuByIds(List<long> skuId)
        {
            return _DbRead.Set<sku>().Where(u=>skuId.Contains(u.id)).ToList();
        }
    }
}
