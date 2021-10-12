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
   public class MenuService:BaseService<menu>, IMenuService
    {
        public MenuService(DbContext Db):base(Db)
        {

        }
        public async Task<bool> DelListByUpdateAsync(List<int> _ids)
        {
            var menuList = await GetEntitiesAsync(u => _ids.Contains(u.id));
            menuList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
            return await UpdateListAsync(menuList);
        }
        public async Task<IEnumerable<menu>> GetAllEntitiesTrueAsync()
        {
            return await GetEntitiesAsync(u => u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
        }
        public async Task<bool> AddEntitesAsync(List<menu> _menus)
        {
            _menus.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Normal);
            return await AddEntitesAsync(_menus);
        }
        public async Task<IEnumerable<menu>> GetEntitiesTrueByIdAsync(List<int> _ids)
        {
            return await GetEntitiesAsync(u => _ids.Contains(u.id));
        }
        public async Task<bool> UpdateEntitesAsync(List<menu> _menus)
        {
            return await UpdateEntitesAsync(_menus);
        }
    }
}
