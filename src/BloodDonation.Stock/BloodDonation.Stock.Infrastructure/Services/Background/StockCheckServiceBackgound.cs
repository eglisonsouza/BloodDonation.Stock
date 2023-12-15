using BloodDonation.Stock.Core.Models.Ui.Settings;
using BloodDonation.Stock.Core.Repositories;
using BloodDonation.Stock.Core.Services.Email;
using BloodDonation.Stock.Core.Services.MessageBus;
using Microsoft.Extensions.Hosting;

namespace BloodDonation.Stock.Infrastructure.Services.Background
{
    public class StockCheckServiceBackgound(
        IStockRepository stockRepository,
        INotificationQueuePublisher notificationQueuePublisher,
        IEmailService emailService,
        AppSettings appSettings) : BackgroundService
    {
        private readonly IStockRepository _stockRepository = stockRepository;
        private readonly INotificationQueuePublisher _notificationQueuePublisher = notificationQueuePublisher;
        private readonly IEmailService _emailService = emailService;
        private readonly BackgroundServiceSettings _backgroundServiceSettings = appSettings.BackgroundService!;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ = new Timer(StockCheck, null, TimeSpan.Zero, TimeSpan.FromSeconds(_backgroundServiceSettings.IntervalInSeconds));

            return Task.CompletedTask;
        }

        private async void StockCheck(object? _)
        {
            var stock = await _stockRepository.GetStock();

            if (stock!.Any())
            {
                _notificationQueuePublisher.Publish(_emailService.GenerateEmail(stock!));
            }
        }
    }
}
