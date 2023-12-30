namespace BloodDonation.Stock.Core.Services.ServiceDiscovery
{
    public interface IServiceDiscoveryService
    {
        Task<string> GetServiceUri(string serviceName);
    }
}
