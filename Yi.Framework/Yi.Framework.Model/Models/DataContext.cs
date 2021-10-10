using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Common.IOCOptions;

namespace Yi.Framework.Model.Models
{
   public class DataContext : DbContext
    {
		private readonly IOptionsMonitor<SqliteOptions> _optionsMonitor;
		private readonly string _connStr;

		public DataContext(IOptionsMonitor<SqliteOptions> optionsMonitor)
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
				optionsBuilder.UseSqlite(_connStr);
			}
		}
		//public virtual DbSet<TbBrand> TbBrand { get; set; }
	}
}
