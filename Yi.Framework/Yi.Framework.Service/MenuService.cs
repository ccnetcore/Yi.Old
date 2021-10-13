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
        public MenuService(DbContext Db) : base(Db) { }

        public async Task<bool> AddChildrenMenu(menu _menu)
        {
            var menu_data = await GetEntity(u=>u.id==_menu.id&& u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            if (menu_data == null)
            {
                return false;
            }         
            menu_data.children.Add(new menu()) ;
            return await AddAsync(_menu);
        }

        public async Task<bool> DelListByUpdateAsync(List<int> _ids)
        {
            var menuList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
            menuList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
            return await UpdateListAsync(menuList);
        }

        public async Task<IEnumerable<menu>> GetAllEntitiesTrueAsync()
        {
            return await GetEntitiesAsync(u => u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
        }

        public async Task<List<menu>> GetChildrenByMenu(menu _menu)
        {
            var menu_data = await GetEntity(u=>u.id==_menu.id&& u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            var childrenList = menu_data.children.ToList();
            return childrenList;
        }

        public async Task<menu> GetMenuMouldByMenu(menu _menu)
        {
            var menu_data = await _Db.Set<menu>().Where(u=>u.id==_menu.id).Include(u=>u.mould).FirstOrDefaultAsync();
            return menu_data;
        }

        public async Task<mould> GetMouldByMenu(menu _menu)
        {
            var menu_data =await _Db.Set<menu>().Include(u => u.mould)
                .Where(u => u.id == _menu.id & u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).FirstOrDefaultAsync();
            return menu_data.mould;
        }

        public async Task<bool> SetMouldByMenu(int mouldId, int menuId)
        {
            var menu_data = await GetEntity(u => u.id == menuId);
            var mould_data = await _Db.Set<mould>().Where(u => u.id==mouldId).FirstOrDefaultAsync();
            menu_data.mould = mould_data;
            return await UpdateAsync(menu_data);
        }
    }
}
