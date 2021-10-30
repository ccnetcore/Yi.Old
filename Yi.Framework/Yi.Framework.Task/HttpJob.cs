using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Job
{
   public class HttpJob : IJob
    {
        private ILogger<VisitJob> _logger;
        public HttpJob(ILogger<VisitJob> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
              
            });
        }
    }
}
