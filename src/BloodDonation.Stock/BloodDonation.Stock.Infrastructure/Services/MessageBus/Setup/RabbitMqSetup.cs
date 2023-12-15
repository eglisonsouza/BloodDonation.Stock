using BloodDonation.Stock.Core.Models.Ui.Settings;
using RabbitMQ.Client;

namespace BloodDonation.Stock.Infrastructure.Services.MessageBus.Setup
{
    public class RabbitMqSetup
    {
        public static ConnectionFactory CreateConnectionFactory(RabbitMqSettings rabbitMq)
        {
#if DEBUG
            return new ConnectionFactory
            {
                HostName = rabbitMq.Host!,
                UserName = rabbitMq.Username!,
                Password = rabbitMq.Password!,
            };
#else
            return new ConnectionFactory
            {
                Uri = new Uri(rabbitMq.Uri!),
            };
#endif
        }

        public static void DeclareQueue(IModel channel, string queue)
        {
            channel.QueueDeclare(
                queue: queue,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }
    }
}
