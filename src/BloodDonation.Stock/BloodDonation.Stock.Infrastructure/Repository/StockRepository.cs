using BloodDonation.Stock.Core.Models.Entities;
using BloodDonation.Stock.Core.Models.Ui.Settings;
using BloodDonation.Stock.Core.Repositories;
using BloodDonation.Stock.Infrastructure.Repository.Scripts;
using Dapper;
using Microsoft.Data.SqlClient;


namespace BloodDonation.Stock.Infrastructure.Repository
{
    public class StockRepository(AppSettings appSettings) : IStockRepository
    {
        private readonly int _quantityMl = appSettings.Stock!.QuantityMl!;
        private readonly string _connectionString = appSettings.Dababase!.ConnectionString!;

        public async Task<IEnumerable<BloodStock?>?> GetStock()
        {
            using var dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            return await dbConnection.QueryAsync<BloodStock>(string.Format(BloodStockScripts.GetStock, _quantityMl));
        }
    }
}
