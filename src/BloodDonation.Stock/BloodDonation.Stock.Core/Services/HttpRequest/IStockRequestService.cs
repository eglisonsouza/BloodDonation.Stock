using BloodDonation.Stock.Core.Models.DTOs;

namespace BloodDonation.Stock.Core.Services.HttpRequest
{
    public interface IStockRequestService
    {
        Task<List<BloodStockDTO>> GetStock();
    }
}
