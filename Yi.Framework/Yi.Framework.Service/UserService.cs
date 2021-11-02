using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Core;
using Yi.Framework.Interface;
using Yi.Framework.Model;
using Yi.Framework.Model.ModelFactory;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Service
{
    public partial class UserService : BaseService<user>, IUserService
    {
        private IRoleService _roleService;
        short Normal = (short)Common.Enum.DelFlagEnum.Normal;
        public UserService(IDbContextFactory DbFactory, IRoleService roleService) : base(DbFactory)
        {
            _roleService = roleService;
        }

        public async Task<bool> EmailIsExsit(string emailAddress)
        {
            var userList = await GetAllEntitiesTrueAsync();
            var is_email = userList.Where(u => u.email == emailAddress).FirstOrDefault();
            if (is_email == null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<user> GetUserById(int userId)
        {
            return await _DbRead.Set<user>().Include(u => u.roles).ThenInclude(u => u.menus).ThenInclude(u => u.children).ThenInclude(u => u.mould).Where(u=>u.id==userId).FirstOrDefaultAsync();

        }
        public async  Task<List<menu>> GetAxiosByRouter(string router, int userId, List<int> menuIds)
        {
            var user_data =await GetUserById(userId);
            List<menu> menuList = new();
           foreach(var item in user_data.roles)
            {
               var m=item.menus.Where(u => u.router.ToUpper() == router.ToUpper()).FirstOrDefault();
               menuList= m.children.Where(u => menuIds.Contains(u.id)&&u.is_delete==Normal).ToList();
                if (m != null) { break; }
            }
            return  menuList;
        }   

        public async Task<menu> GetMenuByHttpUser(int userId)
        {
            var user_data = await GetUserById(userId);
            List<menu> menuList = new();
            foreach (var item in user_data.roles)
            {
                var m = item.menus.Where(u => u.is_delete == Normal).ToList();
                menuList = menuList.Union(m).OrderByDescending(u => u.sort).ToList();
            }
            //menu_data为角色所有的菜单，不是一个递归的啊
            var allMenuIds = menuList.Select(u => u.id).ToList();


            var topMenu =await _DbRead.Set<menu>().Include(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.children).Where(u => u.is_top == (short)Common.Enum.ShowFlagEnum.Show).FirstOrDefaultAsync();

            
            //现在要开始关联菜单了
            return TreeMenuBuild.Sort(TreeMenuBuild.ShowFormat(topMenu, allMenuIds)); ;
        }

      

        public async Task<user> GetUserInRolesByHttpUser(int userId)
        {
           return await GetUserById(userId);          
        }

        public async Task<user> Login(user _user)
        {
            var user_data = await _DbRead.Set<user>().Include(u => u.roles).Where(u => u.username == _user.username && u.password ==_user.password &&u.is_delete == Normal).FirstOrDefaultAsync();
            return user_data;
        }

        public async Task<bool> Register(user _user)
        {
            var user_data = await GetEntity(u => u.username == _user.username);
            if (user_data != null)
            {
                return false;
            }
            return await AddAsync(_user);
        }

        public async Task<bool> SetRoleByUser(List<int> roleIds, List<int> userIds)
        {
            var user_data = await _DbRead.Set<user>().Include(u => u.roles).Where(u => userIds.Contains(u.id)).ToListAsync();          
            var roleList = await _DbRead.Set<role>().Where(u => roleIds.Contains(u.id)).ToListAsync();
            user_data.ForEach(u => u.roles = roleList);          
            return await UpdateListAsync(user_data);
        }
    }
}
