using System.Text.Json.Serialization;

namespace OBilet.Application.Services.Models.Response
{
    public class SessionResponse
    {
        [JsonPropertyName("session-id")]
        public string SessionId { get; set; }

        [JsonPropertyName("device-id")]
        public string DeviceId { get; set; }

        [JsonPropertyName("affiliate")]
        public object Affiliate { get; set; }

        [JsonPropertyName("device-type")]
        public int DeviceType { get; set; }

        [JsonPropertyName("device")]
        public object Device { get; set; }

        [JsonPropertyName("ip-country")]
        public string IpCountry { get; set; }
    }
}
