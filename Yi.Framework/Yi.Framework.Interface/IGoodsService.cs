using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;
using Yi.Framework.Model.Search;

namespace Yi.Framework.Interface
{
    public interface IGoodsService
    {
        Goods GetGoodsBySpuId(int spuId);
        PageResult<spu> QuerySpuByPage(int page, int rows, string key, int? saleable);
        List<spec_param> SpecParam(category _category);
        List<sku> QuerySkuByIds(List<long> skuId);
    }
}
