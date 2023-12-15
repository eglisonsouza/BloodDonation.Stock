using BloodDonation.Stock.Core.Models.Entities;

namespace BloodDonation.Stock.Core.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<BloodStock?>?> GetStock();
    }
}
