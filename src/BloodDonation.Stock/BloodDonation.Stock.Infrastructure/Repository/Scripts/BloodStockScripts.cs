namespace BloodDonation.Stock.Infrastructure.Repository.Scripts
{
    public abstract class BloodStockScripts
    {
        public const string GetStock = @"SELECT Id, BloodType, RhFactor, QuantityMl, CreatedAt, UpdatedAt FROM BloodStocks WHERE QuantityMl <= {0}";
    }
}
