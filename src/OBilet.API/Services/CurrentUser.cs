using Microsoft.AspNetCore.Http;
using OBilet.Application.Common.Interfaces;

namespace OBilet.API.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private string sessionId;
        private string deviceId;

        public string SessionId
        {
            get
            {
                if (string.IsNullOrEmpty(sessionId))
                {
                    var request = _httpContextAccessor.HttpContext?.Request!;

                    if (!request.Headers.TryGetValue("SessionId", out var sessionValue))
                    {
                        throw new InvalidOperationException("The 'SessionId' header is required.");
                    }

                    sessionId = sessionValue;
                }
                
                return sessionId;
            }
        }
        public string DeviceId
        {
            get
            {
                if (string.IsNullOrEmpty(deviceId))
                {
                    var request = _httpContextAccessor.HttpContext?.Request!;

                    if (!request.Headers.TryGetValue("DeviceId", out var deviceValue))
                    {
                        throw new InvalidOperationException("The 'DeviceId' header is required.");
                    }

                    deviceId = deviceValue;
                }

                return deviceId;
            }
        }
    }
}
