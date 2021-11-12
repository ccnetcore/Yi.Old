using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Service
{
    public partial class BrandService:BaseService<brand>, IBrandService
    {
        public async Task<List<brand>> GetBrandsByIds(List<int> ids)
        {
            return await _DbRead.Set<brand>().Where(u => ids.Contains(u.id)).ToListAsync();
        }
    }
}
