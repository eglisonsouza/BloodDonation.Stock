using BloodDonation.Stock.Core.Models.Ui.Settings;
using BloodDonation.Stock.Core.Services.Stock;
using Microsoft.Extensions.Hosting;

namespace BloodDonation.Stock.Infrastructure.Services.Background
{
    public class StockCheckServiceBackgound(
        AppSettings appSettings,
        IStockService stockService) : BackgroundService
    {
        private readonly BackgroundServiceSettings _backgroundServiceSettings = appSettings.BackgroundService!;
        private readonly IStockService _stockService = stockService;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ = new Timer(StockCheck, null, TimeSpan.Zero, TimeSpan.FromSeconds(_backgroundServiceSettings.IntervalInSeconds));

            return Task.CompletedTask;
        }

        private void StockCheck(object? _)
        {
            _stockService.Check();
        }
    }
}
