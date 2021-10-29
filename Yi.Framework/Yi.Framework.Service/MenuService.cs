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
               .Include(u => u.children).ThenInclude(u => u.mould)
               .Include(u=>u.children).ThenInclude(u => u.children).ThenInclude(u => u.mould)
               .Include(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.mould)
               .Include(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.mould)
               .Where(u =>u.is_delete == Normal && u.is_show == (short)Common.Enum.ShowFlagEnum.Show && u.is_top == (short)Common.Enum.TopFlagEnum.Top)
               .OrderByDescending(u=>u.sort)
               .FirstOrDefaultAsync();
         return TopMenuBuild(menu_data); 
        }

        public async Task<List<menu>> GetTopMenusByHttpUser(List<int> menuIds)
        {
           return await _DbRead.Set<menu>().Where(u => menuIds.Contains(u.id)).ToListAsync();
        }

        public async Task<menu> SetMouldByMenu(int id1,int id2)
        {
            var menu_data = await _DbRead.Set<menu>().Include(u => u.mould).Where(u => u.id == id1).FirstOrDefaultAsync();
            var mould_data = await _DbRead.Set<mould>().Where(u => u.id == id1).FirstOrDefaultAsync();
            menu_data.mould = mould_data;
              _Db.Update(menu_data);
            return menu_data;
        }

        /// <summary>
        /// 过滤已经被删除的（这个应该是别的地方有方法的，不应该写到service层里面的）
        /// </summary>
        /// <param name="menu_data"></param>
        /// <returns></returns>
        private menu TopMenuBuild(menu menu_data)
        {
            for (int i = menu_data.children.Count() - 1; i >= 0; i--)
            {
                if (menu_data.children[i].is_delete == (short)Common.Enum.DelFlagEnum.Deleted)
                {
                    menu_data.children.Remove(menu_data.children[i]);
                }
                else if (menu_data.children[i] != null)
                {
                    TopMenuBuild(menu_data.children[i]);
                }
            }
            return menu_data;
        }
        public async Task<List<menu>> GetTopMenuByUserId(int userId)
        {
            throw new Exception();
        }

    }
}
