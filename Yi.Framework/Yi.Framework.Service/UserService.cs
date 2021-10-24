using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Interface;
using Yi.Framework.Model;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Service
{
   public partial class UserService: BaseService<user>,IUserService
    {
        private IRoleService _roleService;
        public UserService(DbContext Db, IRoleService roleService) :base(Db)
        {
            _roleService = roleService;
        }
        public async Task<bool> DelListByUpdateAsync(List<int> _ids)
        {
            var userList = await GetEntitiesAsync(u => _ids.Contains(u.id));
            userList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
            return await UpdateListAsync(userList);
        }

        public async Task<bool> EmailIsExsit(string emailAddress)
        {
            var userList=await  GetAllEntitiesTrueAsync();
            var is_email= userList.Where(u=>u.email==emailAddress).FirstOrDefault();
            if (is_email == null)
            {
                return true;
            }
              return false;
        }

        public async Task<IEnumerable<user>> GetAllEntitiesTrueAsync()
        {
            return await GetEntitiesAsync(u => u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
        }

        public async Task<List<menu>> GetMenusByUser(user _user)
        {
           var user_data= await _Db.Set<user>().Include(u => u.roles).ThenInclude(u=>u.menus).ThenInclude(u=>u.mould)
                .Where(u=>u.id==_user.id&& u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).FirstOrDefaultAsync();
            var role_data =await GetRolesByUser(user_data);
            var menuList = new List<menu>();
            role_data.ForEach(u =>
            {
                var menu_data = _roleService.GetMenusByRole(u);
                menuList = menuList.Concat(menu_data.GetAwaiter().GetResult()).ToList();
            });
            menuList.ForEach(u => u.roles = null);

            return menuList;
        }

        public async Task<List<mould>> GetMouldByUser(user _user)
        {         
            var user_data = await GetEntity(u => u.id == _user.id && u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            var menu = await GetMenusByUser(user_data);
            var mouldList = menu.Select(u=>u.mould).ToList();
            return mouldList;
        }

        public async Task<List<role>> GetRolesByUser(user _user)
        {
            var user_data = await _Db.Set<user>().Include(u=>u.roles)
                .Where(u => u.id == _user.id && u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).FirstOrDefaultAsync();
            var roleList = user_data.roles.Where(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).ToList();
            roleList.ForEach(u => u.users = null);
            return roleList;
        }

        public async Task<user> Login(user _user)
        {
            var user_data =await _Db.Set<user>().Include(u=>u.roles).Where(u => u.username == _user.username&&u.password==_user.password&& 
            u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).FirstOrDefaultAsync();
            
            return user_data;

        }

        public async Task<bool> Register(user _user)
        {
            var user_data =await GetEntity(u => u.username == _user.username);
            if (user_data != null)
            {
                return false;
            }
           return await AddAsync(_user);
        }

        public async Task<bool> SetRolesByUser(List<int> roleIds, List<int> userIds)
        {
            var user_data =await _Db.Set<user>().Include(u=>u.roles).Where(u =>userIds.Contains(u.id) &&u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).ToListAsync();
            if (user_data == null)
            {
                return false;
            }           
            var roleList =await _Db.Set<role>().Where(u => roleIds.Contains(u.id) && u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).ToListAsync();
            foreach(var item in user_data)
            {
                item.roles = roleList;
            }
            
            return await UpdateListAsync(user_data);
        }
        public async Task <List<menu>> GetMenuByUser(user _user)
        {
            var user_data =await _Db.Set<user>().Include(u => u.roles).ThenInclude(u => u.menus)
                .Where(u => u.id == _user.id && u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).FirstOrDefaultAsync();
           var role_data= user_data.roles.ToList();
            List<menu> menu_data = new ();
            foreach (var role in role_data)
            {
                var menu = await _roleService.GetMenusByRole(role);
                menu.ForEach(u=>u.roles=null);
                menu_data = menu_data.Concat(menu).OrderByDescending(u=>u.sort).ToList();               
            }                  
            return menu_data;
        }
        public async Task<user> GetUserInfoById(int user_id)
        {
         var user_data=await    GetUserById(user_id);
            user_data.roles.ToList().ForEach(u => u.users = null);
            return user_data;
        }
        public async Task<user> GetUserById(int user_id)
        {
            var user_data = await _Db.Set<user>().Include(u => u.roles)
                .Where(u => u.id == user_id && u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).FirstOrDefaultAsync();
            return user_data;
        }
        public async Task<List<menu>> GetMenuById(int user_id)
        {
            var user_data = await _Db.Set<user>().Include(u => u.roles).Where(u => u.id == user_id).FirstOrDefaultAsync();
            List<menu> menu_data = new();
          
            foreach (var role in user_data.roles)
            {
                var menu = await _roleService.GetMenusByRole(role);
                menu.ForEach(u => u.roles = null);
                menu_data = menu_data.Union(menu).OrderByDescending(u => u.sort).ToList();
            }
            //menu_data为角色所有的菜单，不是一个递归的啊

            var allMenuIds = menu_data.Select(u => u.id).ToList();
            var topMenu = menu_data.Where(u => u.is_top == (short)Common.Enum.ShowFlagEnum.Show);

            //现在要开始关联菜单了

            List<menu> endMenu = new List<menu>();
            foreach (var item in topMenu)
            {
          var p=    await  _Db.Set<menu>().Where(u=>u.id==item.id).Include(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.children).ThenInclude(u => u.children).ToListAsync();
                endMenu = endMenu.Union(p).ToList();
            }


            return TopMenuBuild2(TopMenuBuild(endMenu, allMenuIds));
        }
        private List<menu> TopMenuBuild(List<menu> menu_data,List<int> allMenuIds)
        {

            for (int i = menu_data.Count() - 1; i >= 0; i--)
            {

                if (menu_data[i].icon == null)
                {
                    menu_data[i].icon = "Yi";
                }

                if (!allMenuIds.Contains(menu_data[i].id) || menu_data[i].is_delete == (short)Common.Enum.DelFlagEnum.Deleted|| menu_data[i].is_show == (short)Common.Enum.ShowFlagEnum.NoShow)
                {
                    menu_data.Remove(menu_data[i]);
                }
                else if (menu_data[i].children != null)
                {
                    menu_data[i].children = TopMenuBuild(menu_data[i].children.ToList(), allMenuIds);
                }
            }
            return menu_data;
        }

        private List<menu> TopMenuBuild2(List<menu> menu_data)
        {

            for (int i = menu_data.Count() - 1; i >= 0; i--)
            {
                if (menu_data[i].children.Count() == 0)
                {
                    menu_data[i].children = null;
                }
                else if (menu_data[i].children != null)
                {
                    menu_data[i].children = TopMenuBuild2(menu_data[i].children.ToList());
                }
            }
            return menu_data;
        }



        public async Task<menu> GetMenuByUserId(string router,int userId)
        {
           var user_data= await _Db.Set<user>().Include(u => u.roles).ThenInclude(u => u.menus).ThenInclude(u => u.mould)
                .Where(u => u.id==userId&&u.is_delete == (short)Common.Enum.DelFlagEnum.Normal && u.is_delete == (short)Common.Enum.ShowFlagEnum.Show).FirstOrDefaultAsync();
           var roleList= user_data.roles.ToList();
            menu menu_data=new();
            foreach(var item in roleList)
            {              
                menu_data = item.menus.Where(u => u.router == router).FirstOrDefault();
            }
           
            return  menu_data;
        }
    }
}
