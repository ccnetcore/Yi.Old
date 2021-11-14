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

        public Goods GetGoodsBySpuId(int spuId)
        {
            throw new NotImplementedException();
        }

        public PageResult<spu> QuerySpuByPage(int page, int rows, string key, int? saleable)
        {
            var spuList = _DbRead.Set<spu>().Include(u => u.cid1).Include(u => u.cid2).Include(u=>u.cid3).Include(u => u.spu_Detail).Include(u => u.brand).Include(u => u.skus).Where(u => u.saleable == saleable && u.is_delete == Normal).OrderByDescending(u => u.last_update_time).Skip((page - 1) * rows).Take(rows).ToList();
            var totalPages = spuList.Count % 2 == 0 ? spuList.Count / rows : spuList.Count / rows + 1;
            spuList.ForEach(u => 
            {
                u.brand.categories = null;
                u.brand.spus = null;
                u.cid1.brands = null;
                u.cid1.chidrens = null;
                u.cid1.spec_Groups = null;
                u.cid1.spec_Params = null;
                u.cid2.brands = null;
                u.cid2.chidrens = null;
                u.cid2.spec_Groups = null;
                u.cid2.spec_Params = null;
                u.cid3.brands = null;
                u.cid3.chidrens = null;
                u.cid3.spec_Groups = null;
                u.cid3.spec_Params = null;
            });
            return new PageResult<spu>() { rows = spuList, total = spuList.Count, totalPages = totalPages };
        }
        public List<spec_param> SpecParam(category _category)
        {
            return _DbRead.Set<spec_param>().Where(u => u.category.id == _category.id ).ToList();

        }
    }
}
