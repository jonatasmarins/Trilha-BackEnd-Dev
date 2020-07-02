using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NivelBasico.Domain.Models;
using NivelBasico_Worker.Services.Interfaces;

namespace NivelBasico_Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public IServiceProvider Services { get; }

        public Worker(ILogger<Worker> logger, IServiceProvider services)
        {
            _logger = logger;
            Services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Iniciando consumo do serviço");

            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Consumindo serviço");

            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IScopedProcessingUserService>();
                await scopedProcessingService.DoWork(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Consumo do serviço finalizado");

            await Task.CompletedTask;
        }
    }
}
