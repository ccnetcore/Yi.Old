using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Interface
{
           
        public partial interface IMenuService:IBaseService<menu>
        {
         Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<menu>> GetAllEntitiesTrueAsync();
        }
        
        public partial interface IMouldService:IBaseService<mould>
        {
         Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<mould>> GetAllEntitiesTrueAsync();
        }
        
        public partial interface IRoleService:IBaseService<role>
        {
         Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<role>> GetAllEntitiesTrueAsync();
        }
        
        public partial interface IUserService:IBaseService<user>
        {
         Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<user>> GetAllEntitiesTrueAsync();
        }
        
        public partial interface IVisitService:IBaseService<visit>
        {
         Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<visit>> GetAllEntitiesTrueAsync();
        }
}
