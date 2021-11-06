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
         Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<brand>> GetAllEntitiesTrueAsync();
        }
        
        public partial interface ICategoryService:IBaseService<category>
        {
         Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<category>> GetAllEntitiesTrueAsync();
        }
        
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
        
        public partial interface IOrderService:IBaseService<order>
        {
         Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<order>> GetAllEntitiesTrueAsync();
        }
        
        public partial interface IRoleService:IBaseService<role>
        {
         Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<role>> GetAllEntitiesTrueAsync();
        }
        
        public partial interface ISkuService:IBaseService<sku>
        {
         Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<sku>> GetAllEntitiesTrueAsync();
        }
        
        public partial interface ISpec_groupService:IBaseService<spec_group>
        {
         Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<spec_group>> GetAllEntitiesTrueAsync();
        }
        
        public partial interface ISpec_paramService:IBaseService<spec_param>
        {
         Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<spec_param>> GetAllEntitiesTrueAsync();
        }
        
        public partial interface ISpuService:IBaseService<spu>
        {
         Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<spu>> GetAllEntitiesTrueAsync();
        }
        
        public partial interface ISpu_detailService:IBaseService<spu_detail>
        {
         Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<spu_detail>> GetAllEntitiesTrueAsync();
        }
        
        public partial interface IStockService:IBaseService<stock>
        {
         Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<stock>> GetAllEntitiesTrueAsync();
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
