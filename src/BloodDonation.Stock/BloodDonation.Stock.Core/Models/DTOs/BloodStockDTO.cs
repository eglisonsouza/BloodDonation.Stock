using System.Text.Json.Serialization;

namespace BloodDonation.Stock.Core.Models.DTOs
{
    public class BloodStockDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("bloodType")]
        public required string BloodType { get; set; }
        [JsonPropertyName("rhFactor")]
        public required string RhFactor { get; set; }
        [JsonPropertyName("quantityMl")]
        public int QuantityMl { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

    }
}
