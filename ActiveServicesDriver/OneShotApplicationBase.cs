using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActiveServicesDriver
{
    public abstract class OneShotApplicationBase : IHostedService, IDisposable
    {
        protected readonly ILogger _logger;
        protected readonly IHostApplicationLifetime _lifetime;
        protected readonly IConfiguration _config;

        public OneShotApplicationBase(ILogger logger, IConfiguration config, IHostApplicationLifetime lifetime)
        {
            _logger = logger;
            _lifetime = lifetime;
            _config = config;
        }


        public abstract void SingletonTask();


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("starting task");

            SingletonTask();

            _lifetime.StopApplication();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("Stopping.");
            return Task.CompletedTask;
        }

        public virtual void Dispose()
        {
        }

    }
}
