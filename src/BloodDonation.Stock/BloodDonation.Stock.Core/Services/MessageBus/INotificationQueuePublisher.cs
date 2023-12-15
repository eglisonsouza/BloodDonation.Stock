using BloodDonation.Stock.Core.Models.Args;

namespace BloodDonation.Stock.Core.Services.MessageBus
{
    public interface INotificationQueuePublisher
    {
        void Publish(EmailArgs email);
    }
}
