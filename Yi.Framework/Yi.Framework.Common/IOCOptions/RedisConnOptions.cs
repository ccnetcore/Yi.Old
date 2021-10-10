using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Common.IOCOptions
{
	public class RedisConnOptions
	{
		public string Host { get; set; }
		public int DB { get; set; } = 0;
		public int Prot { get; set; }
		public string Password { get; set; }
	}

	
}
