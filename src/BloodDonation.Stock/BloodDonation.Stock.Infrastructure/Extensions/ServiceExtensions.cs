using BloodDonation.Stock.Core.Services.Email;
using BloodDonation.Stock.Core.Services.Stock;
using BloodDonation.Stock.Infrastructure.Services.Email;
using BloodDonation.Stock.Infrastructure.Services.Stock;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonation.Stock.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<IStockService, StockService>();

            return services;
        }
    }
}
