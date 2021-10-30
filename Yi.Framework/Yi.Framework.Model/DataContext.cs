using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Common.Const;
using Yi.Framework.Common.IOCOptions;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Model
{
    //Add-Migration yi-1
    //Update-Database yi-1
    public partial class DataContext : DbContext
    {
        //private readonly IOptionsMonitor<MySqlConnOptions> _optionsMonitor;
        public static string _connStr;
        public static string DbSelect = DbConst.Mysql;
        //public DataContext(IOptionsMonitor<MySqlConnOptions> optionsMonitor)
        //{
        //	_optionsMonitor = optionsMonitor;
        //	_connStr = _optionsMonitor.CurrentValue.WriteUrl;
        //}
        public DbContext ToWriteOrRead(string connstr)
        {
            _connStr = connstr;
            return this;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                switch (DbSelect)
                {
                    case DbConst.Mysql:
                        var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));
                        optionsBuilder.UseMySql(_connStr, serverVersion); break;
                    case DbConst.Sqlite:
                        optionsBuilder.UseSqlite(_connStr); break;
                    case DbConst.Sqlserver:
                        optionsBuilder.UseSqlServer(_connStr);break;
                    case DbConst.Oracle:
                        optionsBuilder.UseOracle(_connStr);break;
                    default:
                        Console.WriteLine("错误！请确保你选择了正确的数据库！");break;
                }
            }
        }

    }
}
