using BloodDonation.Stock.Core.Models.DTOs;
using BloodDonation.Stock.Core.Models.Ui.Settings;
using BloodDonation.Stock.Core.Services.HttpRequest;
using BloodDonation.Stock.Core.Services.ServiceDiscovery;
using System.Text.Json;

namespace BloodDonation.Stock.Infrastructure.Services.HttpRequest
{

    public class StockRequestService(
        IHttpRequestService httpRequestService,
        IServiceDiscoveryService serviceDiscoveryService,
        AppSettings appSettings
        ) : IStockRequestService
    {
        private readonly IHttpRequestService _httpRequestService = httpRequestService;
        private readonly IServiceDiscoveryService _serviceDiscoveryService = serviceDiscoveryService;
        private readonly string ServiceName = appSettings.ServiceDiscovery!.ServicesName!.BloodApiDatabase!;
        private readonly string LowStock = appSettings.ServiceDiscovery!.Routes!.LowStock!;

        public async Task<List<BloodStockDTO>> GetStock()
        {
            var response = await _httpRequestService.Get(new Uri(await GetUriLowStock()));

            return JsonSerializer.Deserialize<List<BloodStockDTO>>(response)!;
        }

        private async Task<string> GetUriLowStock()
        {
            return await GetBaseUrl() + LowStock;
        }

        private Task<string> GetBaseUrl()
        {
            return _serviceDiscoveryService.GetServiceUri(ServiceName);

        }
    }

}
