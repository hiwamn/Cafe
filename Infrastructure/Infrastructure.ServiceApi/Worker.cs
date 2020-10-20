using Core.Contracts;
using Core.Entities;
using Enums;
using Infrastructure.ServiceApi.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Utility.SocketHandler.Common;
using Utility.SocketHandler.Server;
using Utility.Tools.General;
using Utility.Tools.Notification;

namespace Infrastructure.ServiceApi
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration configuration;
        private readonly IUnitOfWork unit;
        private readonly INotification not;

        public Worker(
            ILogger<Worker> logger, 
            IServiceScopeFactory nikoSingle,
            IConfiguration configuration
            )
        {
            _logger = logger;
            this.configuration = configuration;
            var scope = nikoSingle.CreateScope();
            unit = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            ServerHandler server = new ServerHandler();
            server.Initial(configuration.BindSection<SocketParameters>());
            while (true)
            {
                try
                {
                    MainLoop();
                }
                catch (Exception e1)
                {

                    Agent.FileLogger(@"C:\Test\ServiceLog.txt", e1.ToString());
                }
            }
        }

        private void MainLoop()
        {
            Thread.Sleep(10);
        }
        
    }


}