using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Yi.Framework.SMSProcessor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _IConfiguration;
        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._IConfiguration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _logger.LogInformation($"Worker appsetting ConsulClientOption:Ip={this._IConfiguration["ConsulClientOption:Ip"]}");
                await Task.Delay(100000, stoppingToken);
            }
        }
    }
}
