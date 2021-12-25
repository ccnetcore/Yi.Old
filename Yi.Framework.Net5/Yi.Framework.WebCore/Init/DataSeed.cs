using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.ModelFactory;
using Yi.Framework.Model.Models;

namespace Yi.Framework.WebCore.Init
{
    public class DataSeed
    {
        public async static Task SeedAsync(IDbContextFactory _DbFactory)
        {
            var _Db = _DbFactory.ConnWriteOrRead(Common.Enum.WriteAndReadEnum.Write);
            if (!_Db.Set<user>().Any())
            {
                await _Db.Set<user>().AddAsync(new user
                {
                    username = "admin",
                    password = "123",
                    roles = new List<role>()
                    {
                        new role(){ role_name="普通用户"},

                        new role()
                        {
                            role_name="管理员",
                            menus = new List<menu>()
                            {
                                new menu()
                                {
                                menu_name="根",is_show=1,is_top=1, children=new List<menu>(){
                                    new menu()
                                    { 
                                    menu_name="首页",is_show=1,router="/"
                                    },

                                     new menu()
                                {
                                    menu_name="用户角色管理",is_show=1, children=new List<menu>()
                                    {
                                        new menu()
                                        {
                                            menu_name="用户管理",router="/AdmUser/", is_show=1,children=new List<menu>()
                                            {
                                                new menu()
                                                {
                                                    menu_name="get",is_show=0,
                                                    mould=new mould()
                                                    {
                                                        mould_name="get",url="/user/getuser"
                                                    }
                                                },
                                                new menu()
                                                {
                                                    menu_name="update",is_show=0,
                                                    mould=new mould()
                                                    {
                                                        mould_name="update",url="/user/updateuser"
                                                    }
                                                },
                                                new menu()
                                                {
                                                    menu_name="del",is_show=0,
                                                    mould=new mould()
                                                    {
                                                        mould_name="del",url="/user/dellistUser"
                                                    }
                                                },
                                                new menu()
                                                {
                                                    menu_name="add",is_show=0,
                                                    mould=new mould()
                                                    {
                                                        mould_name="add",url="/user/adduser"
                                                    }
                                                }
                                            }
                                        },
                                        new menu()
                                        {
                                            menu_name="角色管理",router="/admrole/", is_show=1,children=new List<menu>()
                                            {
                                                new menu()
                                                {
                                                    menu_name="get",is_show=0,
                                                    mould=new mould()
                                                    {
                                                        mould_name="get",url="/role/getrole"
                                                    }
                                                },
                                                new menu()
                                                {
                                                    menu_name="update",is_show=0,
                                                    mould=new mould()
                                                    {
                                                        mould_name="update",url="/role/updaterole"
                                                    }
                                                },
                                                new menu()
                                                {
                                                    menu_name="del",is_show=0,
                                                    mould=new mould()
                                                    {
                                                        mould_name="del",url="/role/dellistrole"
                                                    }
                                                },
                                                new menu()
                                                {
                                                    menu_name="add",is_show=0,
                                                    mould=new mould()
                                                    {
                                                        mould_name="add",url="/role/addrole"
                                                    }
                                                }
                                            }
                                        }
                                    }

                                },
                                 new menu()
                                {
                                    menu_name="角色接口管理",is_show=1, children=new List<menu>()
                                    {
                                        new menu()
                                        {
                                            menu_name="菜单管理",router="/AdmMenu/", is_show=1,children=new List<menu>()
                                            {
                                                new menu()
                                                {
                                                    menu_name="get",is_show=0,
                                                    mould=new mould()
                                                    {
                                                        mould_name="get",url="/Menu/getMenu"
                                                    }
                                                },
                                                new menu()
                                                {
                                                    menu_name="update",is_show=0,
                                                    mould=new mould()
                                                    {
                                                        mould_name="update",url="/Menu/updateMenu"
                                                    }
                                                },
                                                new menu()
                                                {
                                                    menu_name="del",is_show=0,
                                                    mould=new mould()
                                                    {
                                                        mould_name="del",url="/Menu/dellistMenu"
                                                    }
                                                },
                                                new menu()
                                                {
                                                    menu_name="add",is_show=0,
                                                    mould=new mould()
                                                    {
                                                        mould_name="add",url="/Menu/addMenu"
                                                    }
                                                }
                                            }
                                        },
                                        new menu()
                                        {
                                            menu_name="接口管理",router="/admMould/", is_show=1,children=new List<menu>()
                                            {
                                                new menu()
                                                {
                                                    menu_name="get",is_show=0,
                                                    mould=new mould()
                                                    {
                                                        mould_name="get",url="/Mould/getMould"
                                                    }
                                                },
                                                new menu()
                                                {
                                                    menu_name="update",is_show=0,
                                                    mould=new mould()
                                                    {
                                                        mould_name="update",url="/Mould/updateMould"
                                                    }
                                                },
                                                new menu()
                                                {
                                                    menu_name="del",is_show=0,
                                                    mould=new mould()
                                                    {
                                                        mould_name="del",url="/Mould/dellistMould"
                                                    }
                                                },
                                                new menu()
                                                {
                                                    menu_name="add",is_show=0,
                                                    mould=new mould()
                                                    {
                                                        mould_name="add",url="/Mould/addMould"
                                                    }
                                                }
                                            }
                                        },
                                         new menu()
                                        {
                                            menu_name="角色菜单分配管理",router="/admRoleMenu/", is_show=1, children=null
                                        }
                                    }

                                },
                                  new menu()
                                {
                                    menu_name="路由管理",is_show=1,children=new List<menu>()
                                    {
                                        new menu()
                                        {
                                            menu_name="用户信息",router="/userinfo/", is_show=1,children=null

                                        }
                                    }

                                }























                                }
                                }

                            }
                        }
                    }
                });
            }
            await _Db.SaveChangesAsync();

            Console.WriteLine(nameof(DbContext) + ":数据库初始成功！");
        }
    }
}
