using BloodDonation.Stock.Core.Models.Args;
using BloodDonation.Stock.Core.Models.DTOs;

namespace BloodDonation.Stock.Core.Services.Email
{
    public interface IEmailService
    {
        EmailArgs GenerateEmail(IEnumerable<BloodStockDTO> stock);
    }
}
