using BloodDonation.Stock.Core.Services.HttpRequest;

namespace BloodDonation.Stock.Infrastructure.Services.HttpRequest
{
    public class HttpRequestService : IHttpRequestService
    {
        public Task<string> Get(Uri uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri.AbsoluteUri);
            var response = new HttpClient().Send(request);

            return response.Content.ReadAsStringAsync();
        }
    }

}
