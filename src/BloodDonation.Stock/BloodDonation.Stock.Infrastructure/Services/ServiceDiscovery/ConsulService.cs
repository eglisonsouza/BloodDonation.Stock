using BloodDonation.Stock.Core.Models.Ui.Settings;
using BloodDonation.Stock.Core.Services.ServiceDiscovery;
using Consul;

namespace BloodDonation.Stock.Infrastructure.Services.ServiceDiscovery
{
    public class ConsulService(IConsulClient consulClient, AppSettings appSettings) : IServiceDiscoveryService
    {
        private readonly IConsulClient _consulClient = consulClient;
        private readonly string UrlFormat = appSettings.ApiSettings!.UrlFormat!;

        public async Task<string> GetServiceUri(string serviceName)
        {
            var service = await GetService(serviceName);

            return string.Format(UrlFormat, service.Address, service.Port);
        }

        private async Task<AgentService> GetService(string serviceName)
        {
            var servicesRegitereds = await _consulClient.Agent.Services();

            var service = servicesRegitereds.Response.Where(s => s.Value.Service.Equals(serviceName, StringComparison.OrdinalIgnoreCase))
                .Select(s => s.Value).ToList().First();
            return service;
        }
    }
}
