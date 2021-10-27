using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Interface
{
   public partial interface IUserService:IBaseService<user> 
    {   

        /// <summary>
        /// 登录,传入_user需包含用户名与密码/角色
        /// </summary>
        /// <returns></returns>
        Task<user> Login(user _user);

        /// <summary>
        /// 注册，需要检测是否用户名重复
        /// </summary>
        /// <returns></returns>
        Task<bool> Register(user _user);
        /// <summary>
        /// 给多个用户设置多个角色
        /// </summary>
        /// <param name="roleIds"></param>
        /// <param name="userIds"></param>
        /// <returns></returns>
        Task<bool> SetRoleByUser(List<int> roleIds, List<int> userIds);
        /// <summary>
        /// 通过id获取用户信息，关联角色、菜单、子菜单、接口
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<user> GetUserById(int userId);
        /// <summary>
        /// email验证
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        Task<bool> EmailIsExsit(string emailAddress);

        /// <summary>
        /// 通过用户id，得到该用户的所有信息，关联角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<user> GetUserInRolesByHttpUser(int userId);
        /// <summary>
        /// 通过http获取用户id，得到该用户所有的菜单（递归的那种），把所有children为[]的值全部过滤成null,不要绑定mould
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<menu>> GetMenuByHttpUser(int userId);
        /// <summary>
        /// 根据路由获取菜单
        /// </summary>
        /// <param name="router"></param>
        /// <returns></returns>
        Task<List<menu>> GetAxiosByRouter(string router,int userId, List<int> menuIds);

    }
}
