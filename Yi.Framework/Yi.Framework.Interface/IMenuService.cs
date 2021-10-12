using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Interface
{
   public interface IMenuService:IBaseService<menu>
    {
        Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<menu>> GetAllEntitiesTrueAsync();
        Task<IEnumerable<menu>> GetEntitiesTrueByIdAsync(List<int> _ids);
        Task<bool> AddEntitesAsync(List<menu> _menus);
        Task<bool> UpdateEntitesAsync(List<menu> _menus);
    }
}
