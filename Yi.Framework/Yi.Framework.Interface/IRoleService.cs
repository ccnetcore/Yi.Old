using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Interface
{
   public interface IRoleService:IBaseService<role> 
    {
        Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<role>> GetAllEntitiesTrueAsync();
        Task<IEnumerable<role>> GetEntitiesTrueByIdAsync(List<int> _ids);
        Task<bool> AddEntitesAsync(List<role> _roles);
        Task<bool> UpdateEntitesAsync(List<role> _roles);
    }
}
