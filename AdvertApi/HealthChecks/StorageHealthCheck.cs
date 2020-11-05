using AdvertApi.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdvertApi.HealthChecks
{
    public class StorageHealthCheck : IHealthCheck
    {
        private readonly IAdvertStorageService _storageService;

        public StorageHealthCheck(IAdvertStorageService storageService)
        {
            _storageService = storageService;
        }

        //public async ValueTask<IHealthCheckResult> CheckAsync(CancellationToken cancellationToken = default)
        //{
        //    var isStorageOkay = await _storageService.CheckHealthAsync();
        //    return HealthCheckResult.FromStatus(isStorageOkay ? CheckStatus.Healthy : CheckStatus.Unhealthy, "Some description here...");
        //}

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var isStorageOkay = await _storageService.CheckHealthAsync();
                return isStorageOkay ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy();
            }
            catch (Exception e)
            {
                return HealthCheckResult.Unhealthy(e.Message);
            }
        }
    }
}
