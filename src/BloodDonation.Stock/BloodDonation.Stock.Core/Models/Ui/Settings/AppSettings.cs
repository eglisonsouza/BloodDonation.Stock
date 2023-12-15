namespace BloodDonation.Stock.Core.Models.Ui.Settings
{
    public class AppSettings
    {
        public BackgroundServiceSettings? BackgroundService { get; set; }
        public DababaseSettings? Dababase { get; set; }
        public RabbitMqSettings? RabbitMq { get; set; }
        public EmailSettings? Email { get; set; }
        public StockSettings? Stock { get; set; }
    }

    public class StockSettings
    {
        public int QuantityMl { get; set; }
    }

    public class EmailSettings
    {
        public string? SendTo { get; set; }
    }

    public class RabbitMqSettings
    {
        public string? Host { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Uri { get; set; }
    }

    public class DababaseSettings
    {
        public string? ConnectionString { get; set; }
    }

    public class BackgroundServiceSettings
    {
        public int IntervalInSeconds { get; set; }
    }
}
