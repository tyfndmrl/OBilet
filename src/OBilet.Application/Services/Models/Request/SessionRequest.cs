using System.Text.Json.Serialization;

namespace OBilet.Application.Services.Models.Request
{
    public class SessionRequest
    {
        public SessionRequest()
        {
            Connection = new Connection();
            Browser = new Browser();
        }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("connection")]
        public Connection Connection { get; set; }

        [JsonPropertyName("browser")]
        public Browser Browser { get; set; }
    }

    public class Browser
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }

    public class Connection
    {
        [JsonPropertyName("ip-address")]
        public string IpAddress { get; set; }

        [JsonPropertyName("port")]
        public string Port { get; set; }
    }
}
