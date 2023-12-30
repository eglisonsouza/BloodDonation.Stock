namespace BloodDonation.Stock.Core.Services.HttpRequest
{
    public interface IHttpRequestService
    {
        Task<string> Get(Uri uri);
    }
}
