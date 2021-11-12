using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Interface
{
   public partial interface ICategoryService:IBaseService<category>
    {
        Task<List<category>> GetByIds(List<int> ids);
    }
}
