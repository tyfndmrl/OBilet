using OBilet.Application.Messaging;

namespace OBilet.Application.Features.Session.Queries
{
    public class SessionQuery : IQuery<SessionDto>
    {
        public string IpAddress { get; set; }
        public string Port { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
    }
}
