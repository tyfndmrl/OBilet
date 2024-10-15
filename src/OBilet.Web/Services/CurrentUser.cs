using OBilet.Application.Common.Interfaces;
using OBilet.Application.Services;
using OBilet.Application.Services.Models.Request;

namespace OBilet.Web.Services
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
                    GetSessionAsync().Wait();
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
                    GetSessionAsync().Wait();
                }
                return deviceId;
            }
        }


        private async Task GetSessionAsync()
        {
            sessionId = _httpContextAccessor.HttpContext.Request.Cookies["sessionId"];
            deviceId = _httpContextAccessor.HttpContext.Request.Cookies["deviceId"];
            if (string.IsNullOrEmpty(sessionId) || string.IsNullOrEmpty(deviceId))
            {
                var request = new SessionRequest
                {
                    Type = 1,
                    Connection = new Connection
                    {
                        IpAddress = "165.114.41.21",
                        Port = "5117"
                    },
                    Browser = new Browser
                    {
                        Name = "Chrome",
                        Version = "47.0.0.12"
                    }
                };

                var oBiletService = _httpContextAccessor.HttpContext!.RequestServices.GetRequiredService<IOBiletService>();

                var result = await oBiletService.GetSessionAsync(request);
                if (result is not null)
                {
                    sessionId = result.Data?.SessionId;
                    deviceId = result.Data?.DeviceId;

                    _httpContextAccessor.HttpContext.Response.Cookies.Append("sessionId", sessionId, new CookieOptions { HttpOnly = true, Secure = true, SameSite = SameSiteMode.None });
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("deviceId", deviceId, new CookieOptions { HttpOnly = true, Secure = true, SameSite = SameSiteMode.None });
                }
            }
        }
    }
}
