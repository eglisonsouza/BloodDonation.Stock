namespace BloodDonation.Stock.Core.Models.Ui.Settings
{
    public class AppSettings
    {
        public BackgroundServiceSettings? BackgroundService { get; set; }
        public RabbitMqSettings? RabbitMq { get; set; }
        public EmailSettings? Email { get; set; }
        public ApiSettings? ApiSettings { get; set; }
        public ServiceDiscoverySettings? ServiceDiscovery { get; set; }
    }
}
