using BloodDonation.Stock.Core.Models.Enuns;

namespace BloodDonation.Stock.Core.Models.Entities
{
    public class BloodStock
    {
        public Guid Id { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public int QuantityMl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
