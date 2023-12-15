using BloodDonation.Stock.Core.Models.Ui.Settings;
using RabbitMQ.Client;

namespace BloodDonation.Stock.Infrastructure.Services.MessageBus.Setup
{
    public class RabbitMqPublisherSetup(AppSettings appSettings)
    {
        private readonly ConnectionFactory _factory = RabbitMqSetup.CreateConnectionFactory(appSettings.RabbitMq!);

        protected void Publish(string queue, byte[] message)
        {
            using var model = _factory.CreateConnection().CreateModel();
            RabbitMqSetup.DeclareQueue(model, queue);
            Send(queue, message, model);
        }

        private static void Send(string queue, byte[] message, IModel model)
        {
            model.BasicPublish(
                exchange: "",
                routingKey: queue,
                basicProperties: null,
                body: message);
        }
    }
}
