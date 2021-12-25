using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Common.Models;

namespace Yi.Framework.Job
{
   public class HttpJob : IJob
    {
        private ILogger<HttpJob> _logger;
        public HttpJob(ILogger<HttpJob> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                var jobData = context.JobDetail.JobDataMap;
                 string method= jobData[Common.Const.JobConst.method].ToString();
                string url = jobData[Common.Const.JobConst.url].ToString();
                string data="异常！";
                switch (method)
                {
                    case "post":
                        data = Common.Helper.HttpHelper.HttpPost(url);
                        break;
                    case "get":
                         data = Common.Helper.HttpHelper.HttpGet(url);
                        break;
                }

             
                _logger.LogWarning("定时任务开始调度：" + nameof(HttpJob) + ":" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + $"：访问地址为:{url}，结果为:{data}");
                Console.WriteLine($"结果:{data}");
            });
        }
    }
}
