using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Core;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Service
{
   public partial class MenuService:BaseService<menu>, IMenuService
    {
        short Normal = (short)Common.Enum.DelFlagEnum.Normal;
        public async Task<menu> AddChildrenMenu(int menu_id, menu _children)
        {
            var menu_data = await _DbRead.Set<menu>().Include(u => u.children).Where(u => u.id == menu_id).FirstOrDefaultAsync();
            _children.is_top = (short)Common.Enum.TopFlagEnum.Children;          
            menu_data.children.Add(_children);
            await UpdateAsync(menu_data);
            return menu_data;
        }

        public async Task<bool> AddTopMenu(menu _menu)
        {
            _menu.is_top = (short)Common.Enum.TopFlagEnum.Children;

            return await AddAsync(_menu);
        }

        public async Task<menu> GetMenuInMould()
        {
            var menu_data= await _DbRead.Set<menu>().Include(u=>u.mould)
               .Include(u => u.children).ThenInclude(u => u.mould).OrderByDescending(u => u.sort)
               .Include(u=>u.children).ThenInclude(u => u.children).ThenInclude(u => u.mould)
               .Include(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.mould)
               .Include(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.mould)
               .Where(u =>u.is_delete == Normal && u.is_show == (short)Common.Enum.ShowFlagEnum.Show && u.is_top == (short)Common.Enum.TopFlagEnum.Top)
               .FirstOrDefaultAsync();
         return  TreeMenuBuild.Sort(TreeMenuBuild.Normal(menu_data)); 
        }

        public async Task<List<menu>> GetTopMenusByTopMenuIds(List<int> menuIds)
        {
           return await _DbRead.Set<menu>().AsNoTracking().Where(u => menuIds.Contains(u.id)).OrderBy(u=>u.sort).ToListAsync();
        }

        public async Task<menu> SetMouldByMenu(int id1,int id2)
        {
            var menu_data = await _DbRead.Set<menu>().Include(u => u.mould).Where(u => u.id == id1).FirstOrDefaultAsync();
            var mould_data = await _DbRead.Set<mould>().Where(u => u.id == id1).FirstOrDefaultAsync();
            menu_data.mould = mould_data;
              _Db.Update(menu_data);
            return menu_data;
        }

 
        public async Task<List<menu>> GetTopMenuByUserId(int userId)
        {
            var user_data = await _DbRead.Set<user>().Include(u => u.roles).ThenInclude(u => u.menus).Where(u=>u.id==userId).FirstOrDefaultAsync();
            List<menu> menuList = new();
            user_data.roles.ForEach(u =>
            {
                var m = u.menus.Where(u => u.is_delete == Normal).ToList();
                menuList = menuList.Union(m).ToList();
            });
            return menuList;
        }

    }
}
