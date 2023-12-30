using BloodDonation.Stock.Core.Services.Email;
using BloodDonation.Stock.Core.Services.HttpRequest;
using BloodDonation.Stock.Core.Services.MessageBus;
using BloodDonation.Stock.Core.Services.Stock;

namespace BloodDonation.Stock.Infrastructure.Services.Stock
{
    public class StockService(
        IStockRequestService stockRequestService,
        INotificationQueuePublisher notificationQueuePublisher,
        IEmailService emailService) : IStockService
    {
        private readonly IStockRequestService _stockRequestService = stockRequestService;
        private readonly INotificationQueuePublisher _notificationQueuePublisher = notificationQueuePublisher;
        private readonly IEmailService _emailService = emailService;

        public async void Check()
        {
            var stock = await _stockRequestService.GetStock();

            if (stock!.Count != 0)
            {
                _notificationQueuePublisher.Publish(_emailService.GenerateEmail(stock!));
            }
        }
    }
}
