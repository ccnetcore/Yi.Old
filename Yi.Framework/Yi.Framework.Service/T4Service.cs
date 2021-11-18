using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;
using Yi.Framework.Interface;
using Microsoft.EntityFrameworkCore;
using Yi.Framework.Model.ModelFactory;

namespace Yi.Framework.Service
{
           
        public partial class BrandService:BaseService<brand>,IBrandService 
        {
            public BrandService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var brandList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                brandList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(brandList);
            }

            public async Task<IEnumerable<brand>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
        
        public partial class CategoryService:BaseService<category>,ICategoryService 
        {
            public CategoryService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var categoryList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                categoryList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(categoryList);
            }

            public async Task<IEnumerable<category>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
        
        public partial class MenuService:BaseService<menu>,IMenuService 
        {
            public MenuService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var menuList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                menuList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(menuList);
            }

            public async Task<IEnumerable<menu>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
        
        public partial class MouldService:BaseService<mould>,IMouldService 
        {
            public MouldService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var mouldList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                mouldList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(mouldList);
            }

            public async Task<IEnumerable<mould>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
        
        public partial class OrderService:BaseService<order>,IOrderService 
        {
            public OrderService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<string> _ids)
            {
                var orderList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                orderList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(orderList);
            }

            public async Task<IEnumerable<order>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
        
        public partial class RoleService:BaseService<role>,IRoleService 
        {
            public RoleService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var roleList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                roleList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(roleList);
            }

            public async Task<IEnumerable<role>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
        
        public partial class SkuService:BaseService<sku>,ISkuService 
        {
            public SkuService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var skuList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                skuList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(skuList);
            }

            public async Task<IEnumerable<sku>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
        
        public partial class Spec_groupService:BaseService<spec_group>,ISpec_groupService 
        {
            public Spec_groupService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var spec_groupList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                spec_groupList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(spec_groupList);
            }

            public async Task<IEnumerable<spec_group>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
        
        public partial class Spec_paramService:BaseService<spec_param>,ISpec_paramService 
        {
            public Spec_paramService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var spec_paramList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                spec_paramList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(spec_paramList);
            }

            public async Task<IEnumerable<spec_param>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
        
        public partial class SpuService:BaseService<spu>,ISpuService 
        {
            public SpuService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var spuList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                spuList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(spuList);
            }

            public async Task<IEnumerable<spu>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
        
        public partial class Spu_detailService:BaseService<spu_detail>,ISpu_detailService 
        {
            public Spu_detailService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var spu_detailList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                spu_detailList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(spu_detailList);
            }

            public async Task<IEnumerable<spu_detail>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
        
        public partial class StockService:BaseService<stock>,IStockService 
        {
            public StockService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var stockList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                stockList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(stockList);
            }

            public async Task<IEnumerable<stock>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
        
        public partial class UserService:BaseService<user>,IUserService 
        {
            public UserService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var userList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                userList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(userList);
            }

            public async Task<IEnumerable<user>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
        
        public partial class VisitService:BaseService<visit>,IVisitService 
        {
            public VisitService(IDbContextFactory DbFactory):base(DbFactory){ }

            public async Task<bool> DelListByUpdateAsync(List<int> _ids)
            {
                var visitList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
                visitList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
                return await UpdateListAsync(visitList);
            }

            public async Task<IEnumerable<visit>> GetAllEntitiesTrueAsync()
            {
                return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            }

        }
}
