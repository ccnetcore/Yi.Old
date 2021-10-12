using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Common.IOCOptions
{
	public class KafkaOptions
	{
		public string BrokerList { get; set; }
		public string TopicName { get; set; }
	}
}
