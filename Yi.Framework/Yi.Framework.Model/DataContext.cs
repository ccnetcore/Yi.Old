using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Common.IOCOptions;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Model
{
	//Add-Migration yi-1
	//Update-Database yi-1
   public partial class DataContext : DbContext
    {
		private readonly IOptionsMonitor<MySqlConnOptions> _optionsMonitor;
		private readonly string _connStr;

		public DataContext(IOptionsMonitor<MySqlConnOptions> optionsMonitor)
		{
			_optionsMonitor = optionsMonitor;
			_connStr = _optionsMonitor.CurrentValue.Url;
		}

		public DataContext(string connstr)
		{
			_connStr = connstr;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				//optionsBuilder.UseSqlite(_connStr);
				var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));
				optionsBuilder.UseMySql(_connStr, serverVersion);
			}
		}
      
    }
}
