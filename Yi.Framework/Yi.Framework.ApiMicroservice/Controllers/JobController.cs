using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Common;
using Yi.Framework.Common.Const;
using Yi.Framework.Common.Helper;
using Yi.Framework.Common.Models;
using Yi.Framework.Core;
using Yi.Framework.DTOModel;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;

namespace Yi.Framework.ApiMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class JobController : Controller
    {
        private readonly ILogger<JobController> _logger;
        private QuartzInvoker _quartzInvoker;
        public JobController(ILogger<JobController> logger,QuartzInvoker quartzInvoker)
        {
            _logger = logger;
            _quartzInvoker = quartzInvoker;
        }

        [HttpPost]
        public async Task<Result> startJob()
        {
            //任务1
            //await _quartzInvoker.start("*/1 * * * * ? ", new Quartz.JobKey("test", "my"), "VisitJob");

            //任务2
            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {JobConst.method,"get" },
                {JobConst.url,"https://www.baidu.com" }
            };
           await _quartzInvoker.start("*/1 * * * * ? ", new Quartz.JobKey("test", "my"), "HttpJob",data: data);
            return Result.Success();
        }

        [HttpGet]
        public async Task<Result> getRunJobList()
        {
           return  Result.Success().SetData(await _quartzInvoker.getRunJobList());
        }

        [HttpGet]
        public Result  getJobClass()
        {
            return Result.Success().SetData(_quartzInvoker.getJobClassList());
        }

        [HttpPut]
        public async Task<Result> stopJob()
        {
            await _quartzInvoker.Stop(new Quartz.JobKey("test", "my"));
          return Result.Success();
        }

        [HttpDelete]
        public async Task<Result> DeleteJob()
        {
            await _quartzInvoker.Delete(new Quartz.JobKey("test", "my"));
            return Result.Success();
        }

        [HttpPut]
        public async Task<Result> ResumeJob()
        {
            await _quartzInvoker.Resume(new Quartz.JobKey("test", "my"));
            return Result.Success();
        }
    }
}