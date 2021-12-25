
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Common.Models;
using Yi.Framework.Model.ModelFactory;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Job
{
    public class VisitJob : IJob
    {
        private ILogger<VisitJob> _logger;
        private DbContext _DBWrite;
        public VisitJob(ILogger<VisitJob> logger, IDbContextFactory DbFactory)
        {
            _logger = logger;
            _DBWrite = DbFactory.ConnWriteOrRead(Common.Enum.WriteAndReadEnum.Write);
        }

        /// <summary>
        /// 应该将拜访清零，并且写入数据库中的拜访表中
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                _DBWrite.Set<visit>().Add(new visit() { num = JobModel.visitNum, time = DateTime.Now });
                _DBWrite.SaveChanges();
                _logger.LogWarning("定时任务开始调度：" + nameof(VisitJob) + ":" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + $"：访问总数为:{JobModel.visitNum}");
                JobModel.visitNum = 0;
            }
            );
        }
    }
}

