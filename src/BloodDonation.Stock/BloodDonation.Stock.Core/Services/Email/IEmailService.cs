using BloodDonation.Stock.Core.Models.Args;
using BloodDonation.Stock.Core.Models.Entities;

namespace BloodDonation.Stock.Core.Services.Email
{
    public interface IEmailService
    {
        EmailArgs GenerateEmail(IEnumerable<BloodStock> stock);
    }
}
