using BloodDonation.Stock.Core.Models.Args;
using BloodDonation.Stock.Core.Models.DTOs;
using BloodDonation.Stock.Core.Models.Ui.Settings;
using BloodDonation.Stock.Core.Services.Email;
using BloodDonation.Stock.Infrastructure.Templates;

namespace BloodDonation.Stock.Infrastructure.Services.Email
{
    public class EmailService(AppSettings appSettings) : IEmailService
    {
        private readonly string SendToEmail = appSettings.Email!.SendTo!;

        public EmailArgs GenerateEmail(IEnumerable<BloodStockDTO> stock)
        {
            return new EmailArgs(
                               to: SendToEmail,
                               message: GenerateMessage(stock),
                               subject: EmailTemplate.Subject);
        }

        private static string GenerateMessage(IEnumerable<BloodStockDTO> stock) => EmailTemplate.Body(stock);
    }
}
