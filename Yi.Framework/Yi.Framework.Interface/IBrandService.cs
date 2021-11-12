using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Interface
{
    public partial interface IBrandService:IBaseService<brand>
    {
        Task<List<brand>> GetByIds(List<int> ids);
    }
}
