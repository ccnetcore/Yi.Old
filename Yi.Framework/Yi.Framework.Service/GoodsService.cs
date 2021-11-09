using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;
using Yi.Framework.Model.Search;

namespace Yi.Framework.Service
{
    public class GoodsService : IGoodsService
    {
        public PageResult<spu> QuerySpuByPage(int page, int rows, string key, bool? saleable)
        {
            throw new NotImplementedException();
        }
    }
}
