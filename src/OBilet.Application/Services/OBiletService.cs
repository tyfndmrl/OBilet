using Microsoft.Extensions.Options;
using OBilet.Application.Common.Interfaces;
using OBilet.Application.Services.Configurations;
using OBilet.Application.Services.Models.Request;
using OBilet.Application.Services.Models.Response;
using System.Text;
using System.Text.Json;

namespace OBilet.Application.Services
{
    public class OBiletService : IOBiletService
    {
        private readonly HttpClient _httpClient;
        private readonly OBiletConfiguration _oBiletConfiguration;
        private readonly ICurrentUser _currentUser;

        public OBiletService(HttpClient httpClient, IOptions<OBiletConfiguration> oBiletConfiguration, ICurrentUser currentUser)
        {
            _httpClient = httpClient;
            _oBiletConfiguration = oBiletConfiguration.Value;
            _currentUser = currentUser;
        }

        public async Task<BaseResponse<List<BusLocationResponse>>> GetBusLocationAsync(BusLocationRequest request)
        {
            request.DeviceSession = GetDeviceSession();
            return await PostAsync<BusLocationRequest, BaseResponse<List<BusLocationResponse>>>(_oBiletConfiguration.GetLocationUrl, request);
        }

        public async Task<BaseResponse<SessionResponse>> GetSessionAsync(SessionRequest request)
        {
            return await PostAsync<SessionRequest, BaseResponse<SessionResponse>>(_oBiletConfiguration.GetSessionUrl, request);
        }

        public async Task<BaseResponse<List<BusJourneyResponse>>> GetBusJourneyAsync(BusJourneyRequest request)
        {
            request.DeviceSession = GetDeviceSession();
            return await PostAsync<BusJourneyRequest, BaseResponse<List<BusJourneyResponse>>>(_oBiletConfiguration.GetJourneyUrl, request);
        }

        private DeviceSession GetDeviceSession()
        {
            return new DeviceSession
            {
                SessionId = _currentUser.SessionId,
                DeviceId = _currentUser.DeviceId
            };
        }

        private async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request) where TResponse : BaseResponse
        {
            var options = new JsonSerializerOptions { IgnoreNullValues = true, WriteIndented = true };
            var requestJson = JsonSerializer.Serialize(request, options);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(responseJson);
        }
    }
}
