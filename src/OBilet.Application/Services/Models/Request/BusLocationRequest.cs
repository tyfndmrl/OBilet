using System.Text.Json.Serialization;

namespace OBilet.Application.Services.Models.Request
{
    public class BusLocationRequest : BaseRequest<string>
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }
    }
}
