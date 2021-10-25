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
        public async Task<menu> AddChildrenMenu(int menu_id, menu _children)
        {
            var menu_data = await _Db.Set<menu>().Include(u => u.children).Where(u => u.id == menu_id).FirstOrDefaultAsync();
            _children.is_top = (short)Common.Enum.TopFlagEnum.Children;          
            menu_data.children.Add(_children);
            await UpdateAsync(menu_data);
            return menu_data;
        }

        /// <summary>
        /// 这个getEntity没有关联子类，怎么能得到子类呢？这是一个错误的接口
        /// </summary>
        /// <param name="_menu"></param>
        /// <returns></returns>
        public async Task<List<menu>> GetChildrenByMenu(menu _menu)
        {
            var menu_data = await GetEntity(u=>u.id==_menu.id&& u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            var childrenList = menu_data.children.ToList();
            return childrenList;
        }

        /// <summary>
        /// 不要返回一个新创的变量，直接返回menu.children,只要id，就不要传一个对象
        /// </summary>
        /// <param name="_menu"></param>
        /// <returns></returns>
        public async Task<List<menu>> GetChildrenMenu(menu _menu)
        {
            var menu= await _Db.Set<menu>().Include(u => u.children).Include(u=>u.mould)
                .Where(u =>u.id==_menu.id&& u.is_top == (short)Common.Enum.TopFlagEnum.Children )
                .FirstOrDefaultAsync();
            var childrenList = menu.children.ToList();
            return childrenList;
        }

        public async Task<List<menu>> GetMenuMould()
        {
           var menuList= await _Db.Set<menu>().Include(u => u.children).Include(u => u.mould)
                .Where(u => u.is_delete == (short)Common.Enum.DelFlagEnum.Normal )
                .ToListAsync();
            return menuList;
        }

        /// <summary>
        ///  和GetChildrenMenu方法可以合并
        /// </summary>
        /// <param name="_menu"></param>
        /// <returns></returns>
        public async Task<menu> GetMenuMouldByMenu(menu _menu)
        {
            var menu_data = await _Db.Set<menu>().Include(u => u.children).Include(u=>u.mould)
                .Where(u=>u.id==_menu.id&& u.is_delete == (short)Common.Enum.ShowFlagEnum.Show)
                .FirstOrDefaultAsync();
            return menu_data;
        }

        public async Task<mould> GetMouldByMenu(menu _menu)
        {
            var menu_data =await _Db.Set<menu>().Include(u => u.mould).Where(u => u.id == _menu.id).FirstOrDefaultAsync();
            return menu_data.mould;
        }

        /// <summary>
        /// 5层迭代
        /// </summary>
        /// <returns></returns>
        public async Task<List<menu>> GetTopMenu()
        {
            var menu_data= await _Db.Set<menu>().Include(u=>u.mould)
               .Include(u => u.children).ThenInclude(u => u.mould)
               .Include(u=>u.children).ThenInclude(u => u.children).ThenInclude(u => u.mould)
               .Include(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.mould)
               .Include(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.mould)
               .Where(u =>u.is_delete == (short)Common.Enum.DelFlagEnum.Normal && u.is_top == (short)Common.Enum.ShowFlagEnum.Show)
               .OrderByDescending(u=>u.sort)
               .ToListAsync();
         return TopMenuBuild(menu_data); 
        }
        /// <summary>
        /// 过滤已经被删除的（这个应该是别的地方有方法的，不应该写到service层里面的）
        /// </summary>
        /// <param name="menu_data"></param>
        /// <returns></returns>
        private List<menu> TopMenuBuild(List<menu> menu_data)
        {
            for(int i = menu_data.Count()-1; i >=0; i--)
            {
                if(menu_data[i].is_delete == (short)Common.Enum.DelFlagEnum.Deleted)
                {
                    menu_data.Remove(menu_data[i]);
                }
                else if(menu_data[i].children != null)
                {               
                    menu_data[i].children= TopMenuBuild(menu_data[i].children.ToList());
               } 
            }
            return menu_data;
        }

        /// <summary>
        /// 要关联啊，menudata要关联mould，而且能用find就用find
        /// </summary>
        /// <param name="mouldId"></param>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public async Task<bool> SetMouldByMenu(int mouldId, int menuId)
        {
            var menu_data = await GetEntity(u => u.id == menuId);
            var mould_data = await _Db.Set<mould>().Where(u => u.id==mouldId).FirstOrDefaultAsync();
            menu_data.mould = mould_data;
            return await UpdateAsync(menu_data);
        }
        
    }
}
