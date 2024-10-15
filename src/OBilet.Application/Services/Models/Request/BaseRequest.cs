using System.Text.Json.Serialization;

namespace OBilet.Application.Services.Models.Request
{
    public class BaseRequest<TRequest>
    {
        [JsonPropertyName("data")]
        public TRequest Data { get; set; }

        [JsonPropertyName("device-session")]
        public DeviceSession DeviceSession { get; set; }
    }

    public class DeviceSession
    {
        [JsonPropertyName("session-id")]
        public string SessionId { get; set; }

        [JsonPropertyName("device-id")]
        public string DeviceId { get; set; }
    }
}
