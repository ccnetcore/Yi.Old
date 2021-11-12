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
    public partial class CategoryService:BaseService<category>, ICategoryService
    {
        public async Task<List< category>> GetByIds(List< int> ids)
        {
            return await _DbRead.Set<category>().Where(u => ids.Contains(u.id)).ToListAsync();
        }
    }
}
