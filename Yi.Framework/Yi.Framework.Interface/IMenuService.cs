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
        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<menu>> GetAllEntitiesTrueAsync();

        /// <summary>
        /// 通过menu得到mould（1对1关系）
        /// </summary>
        /// <param name="_menu"></param>
        /// <returns></returns>
        Task<mould> GetMouldByMenu(menu _menu);

        /// <summary>
        /// 通过menu得到他自己与mould（注意：确保返回的menu里含有mould）
        /// </summary>
        /// <param name="_menu"></param>
        /// <returns></returns>
        Task<menu> GetMenuMouldByMenu(menu _menu);

        /// <summary>
        /// 得到该菜单下所有的子类
        /// </summary>
        /// <param name="_menu"></param>
        /// <returns></returns>
        Task<List<menu>> GetChildrenByMenu(menu _menu);

        /// <summary>
        /// 给菜单设置接口（1对1关系）
        /// </summary>
        /// <param name="mouldId"></param>
        /// <param name="menuId"></param>
        /// <returns></returns>
        Task<bool> SetMouldByMenu(int mouldId,int menuId);
        /// <summary>
        /// 添加子菜单
        /// </summary>
        /// <param name="_menu"></param>
        /// <returns></returns>
        Task<menu> AddChildrenMenu(menu _menu, menu _children);
        /// <summary>
        /// 获取根目录菜单
        /// </summary>
        /// <returns></returns>
        Task<List<menu>> GetTopMenu();
        /// <summary>
        /// 获取子菜单
        /// </summary>
        /// <returns></returns>
        Task<List<menu>> GetChildrenMenu(menu _menu);
       
    }
}
