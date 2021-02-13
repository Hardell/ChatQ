﻿using AspNetCoreSpa.Infrastructure.OnlineUserManager;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

public class ConsumeScopedServiceHostedService : BackgroundService
{
    public ConsumeScopedServiceHostedService(IServiceProvider services)
    {
        Services = services;
    }

    public IServiceProvider Services { get; }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await DoWork(stoppingToken);
    }

    private async Task DoWork(CancellationToken stoppingToken)
    {

        using (var scope = Services.CreateScope())
        {
            var scopedProcessingService = scope.ServiceProvider.GetRequiredService<OnlineTimeCounterService>();

            await scopedProcessingService.Count(stoppingToken);
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        await base.StopAsync(stoppingToken);
    }
}