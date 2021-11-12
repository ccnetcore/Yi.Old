using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public PageResult<spu> QuerySpuByPage(int page, int rows, string key, int? saleable)
        {
            var spuList = _DbRead.Set<spu>().Include(u => u.cid1).Include(u => u.cid2).Include(u => u.cid3).Include(u => u.spu_Detail).Include(u => u.brand).Include(u => u.skus).Where(u => u.saleable == saleable && u.title.Contains(key) && u.is_delete == Normal).OrderByDescending(u => u.last_update_time).Skip((page - 1) * rows).Take(rows).ToList();
            var totalPages = spuList.Count % 2 == 0 ? spuList.Count / rows : spuList.Count / rows + 1;
            return new PageResult<spu>() { rows = spuList, total = spuList.Count, totalPages = totalPages };
        }
        public List<spec_param> SpecParam(category _category, int generic)
        {
            return _DbRead.Set<spec_param>().Include(u => u.category).Where(u => u.category == _category && u.generic == generic).ToList();

        }
    }
}
