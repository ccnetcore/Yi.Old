using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Model.DbInit
{
    public class DataSeed
    {
        public async static Task SeedAsync(DbContext _Db)
        {
            if (!_Db.Set<user>().Any())
            {
                await _Db.Set<user>().AddAsync(new user
                {
                    username = "admin",
                    password = "123",
                    roles = new List<role>()
                    {
                        new role()
                        {
                            role_name="管理员",
                            menus = new List<menu>()
                            {
                                new menu() 
                                { 
                                    menu_name="用户角色管理",is_show=1,children=new List<menu>()
                                    {
                                        new menu()
                                        { 
                                            menu_name="用户管理",router="/AdmUser", is_show=1,children=new List<menu>()
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
                                                        mould_name="del",url="/user/adduser"
                                                    }
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
