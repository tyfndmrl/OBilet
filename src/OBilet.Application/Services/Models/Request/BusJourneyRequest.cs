using System.Text.Json.Serialization;

namespace OBilet.Application.Services.Models.Request
{
    public class BusJourneyRequest : BaseRequest<Journey>
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }
    }

    public class Journey
    {
        [JsonPropertyName("origin-id")]
        public int OriginId { get; set; }

        [JsonPropertyName("destination-id")]
        public int DestinationId { get; set; }

        [JsonPropertyName("departure-date")]
        public string DepartureDate { get; set; }
    }
}
