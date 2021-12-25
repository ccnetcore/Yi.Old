using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Core
{
    public static class TreeMenuBuild
    {
        /// <summary>
        /// 过滤所有已经删除的菜单
        /// </summary>
        /// <param name="menu_data"></param>
        /// <returns></returns>
        public static menu Normal(menu menu_data)
        {
            for (int i = menu_data.children.Count() - 1; i >= 0; i--)
            {
                if (menu_data.children[i].is_delete == (short)Common.Enum.DelFlagEnum.Deleted)
                {
                    menu_data.children.Remove(menu_data.children[i]);
                }
                else if (menu_data.children[i] != null)
                {
                    Normal(menu_data.children[i]);
                }
            }
            return menu_data;
        }



        public static menu ShowFormat(menu menu_data, List<int> allMenuIds)
        {
            return Format(Show(menu_data, allMenuIds));
        }



        /// <summary>
        /// 过滤用户不展示及已删除及未拥有的菜单
        /// </summary>
        /// <param name="menu_data"></param>
        /// <param name="allMenuIds"></param>
        /// <returns></returns>
        private static menu Show(menu menu_data, List<int> allMenuIds)
        {
            for (int i = menu_data.children.Count() - 1; i >= 0; i--)
            {
                if (!allMenuIds.Contains(menu_data.children[i].id) || menu_data.children[i].is_delete == (short)Common.Enum.DelFlagEnum.Deleted || menu_data.children[i].is_show == (short)Common.Enum.ShowFlagEnum.NoShow)
                {
                    menu_data.children.Remove(menu_data.children[i]);
                }
                else
                {
                    Show(menu_data.children[i], allMenuIds);
                }
            }
            return menu_data;
        }

        /// <summary>
        /// 为了匹配前端格式，通常和show方法一起
        /// </summary>
        /// <param name="menu_data"></param>
        /// <returns></returns>
        private static menu Format(menu menu_data)
        {
            for (int i = menu_data.children.Count() - 1; i >= 0; i--)
            {
                if (menu_data.children[i].icon == null)
                {
                    menu_data.children[i].icon = "mdi-view-dashboard";
                }
                if (menu_data.children != null || menu_data.children.Count() != 0)
                {
                    Format(menu_data.children[i]);
                }
            }
            if (menu_data.children.Count() == 0)
            {
                menu_data.children = null;
            }

            return menu_data;
        }

        public static menu Sort(menu menu_data)
        {
            if (menu_data.children != null)
            {
                for (int i = menu_data.children.Count() - 1; i >= 0; i--)
                {
                    menu_data.children = menu_data.children.AsEnumerable().OrderByDescending(u => u.sort).ToList();

                    if (menu_data.children != null || menu_data.children.Count() != 0)
                    {
                        Sort(menu_data.children[i]);
                    }
                }
            }
            return menu_data;
        }

    }
}
