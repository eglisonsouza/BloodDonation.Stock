using BloodDonation.Stock.Infrastructure.Services.Background;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonation.Stock.Infrastructure.Extensions
{
    public static class HostedServiceExtensions
    {
        public static IServiceCollection AddHostedServices(this IServiceCollection services)
        {
            services.AddHostedService<StockCheckServiceBackgound>();

            return services;
        }
    }
}
