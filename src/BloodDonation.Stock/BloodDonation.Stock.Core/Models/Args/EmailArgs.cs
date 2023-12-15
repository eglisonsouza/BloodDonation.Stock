using System.Text;
using System.Text.Json;

namespace BloodDonation.Stock.Core.Models.Args
{
    public class EmailArgs(string to, string message, string subject)
    {
        public string To { get; set; } = to;
        public string Subject { get; set; } = subject;
        public string Body { get; set; } = message;

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public byte[] ToBytes()
        {
            return Encoding.UTF8.GetBytes(ToJson());
        }
    }
}
