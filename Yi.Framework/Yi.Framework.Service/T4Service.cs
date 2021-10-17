using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;
using Yi.Framework.Interface;
using Microsoft.EntityFrameworkCore;

namespace Yi.Framework.Service
{
           
        public partial class MenuService:BaseService<menu>,IMenuService 
        {
            //public MenuService(DbContext Db):base(Db){ }
        }
        
        public partial class MouldService:BaseService<mould>,IMouldService 
        {
            //public MouldService(DbContext Db):base(Db){ }
        }
        
        public partial class RoleService:BaseService<role>,IRoleService 
        {
            //public RoleService(DbContext Db):base(Db){ }
        }
        
        public partial class UserService:BaseService<user>,IUserService 
        {
            //public UserService(DbContext Db):base(Db){ }
        }
}
