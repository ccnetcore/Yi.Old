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
        Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<user>> GetAllEntitiesTrueAsync();

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
        /// 根据http上下文的用户得到该用户有哪些角色
        /// </summary>
        /// <returns></returns>
        Task<List<role>> GetRolesByUser(user _user);

        /// <summary>
        /// 得到该用户拥有哪些菜单（注意：每一个菜单需要绑定好对应mould）
        /// </summary>
        /// <param name="_user"></param>
        /// <returns></returns>
        Task<List<menu>> GetMenusByUser(user _user);

        /// <summary>
        /// 得到该用户拥有哪些mould
        /// </summary>
        /// <param name="_user"></param>
        /// <returns></returns>
        Task<List<mould>> GetMouldByUser(user _user);

        /// <summary>
        /// 给单个用户设置多个角色
        /// </summary>
        /// <param name="roleIds"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> SetRolesByUser(List<int> roleIds, List<int> userIds);
        /// <summary>
        /// email验证
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        Task<bool> EmailIsExsit(string emailAddress);
        /// <summary>
        /// 获取用户的目录菜单，没有绑定接口
        /// </summary>
        /// <param name="_user"></param>
        /// <returns></returns>
        Task<List<menu>> GetMenuByUser(user _user);
        /// <summary>
        /// 通过用户id，得到该用户的所有信息，关联角色
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        Task<user> GetUserInfoById(int user_id);
    }
}
