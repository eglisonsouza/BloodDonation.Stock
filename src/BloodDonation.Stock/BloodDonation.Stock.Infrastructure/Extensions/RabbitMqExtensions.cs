using BloodDonation.Stock.Core.Services.MessageBus;
using BloodDonation.Stock.Infrastructure.Services.MessageBus.Queues.Publishers;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonation.Stock.Infrastructure.Extensions
{
    public static class RabbitMqExtensions
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services)
        {
            services.AddSingleton<INotificationQueuePublisher, NotificationQueuePublisher>();

            return services;
        }
    }

}
