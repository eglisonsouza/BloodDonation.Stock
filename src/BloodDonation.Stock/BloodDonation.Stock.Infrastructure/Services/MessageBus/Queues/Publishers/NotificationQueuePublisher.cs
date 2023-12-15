using BloodDonation.Stock.Core.Models.Args;
using BloodDonation.Stock.Core.Models.Ui.Settings;
using BloodDonation.Stock.Core.Services.MessageBus;
using BloodDonation.Stock.Infrastructure.Services.MessageBus.Setup;

namespace BloodDonation.Stock.Infrastructure.Services.MessageBus.Queues.Publishers
{
    public class NotificationQueuePublisher(AppSettings appSettings) : RabbitMqPublisherSetup(appSettings), INotificationQueuePublisher
    {
        private const string NotificationQueue = "email";

        public void Publish(EmailArgs email)
        {
            Publish(NotificationQueue, email.ToBytes());
        }
    }
}
