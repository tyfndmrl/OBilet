using OBilet.Application.Services.Models.Request;
using OBilet.Application.Services.Models.Response;

namespace OBilet.Application.Services
{
    public interface IOBiletService
    {
        Task<BaseResponse<List<BusLocationResponse>>> GetBusLocationAsync(BusLocationRequest request);
        Task<BaseResponse<SessionResponse>> GetSessionAsync(SessionRequest request);
        Task<BaseResponse<List<BusJourneyResponse>>> GetBusJourneyAsync(BusJourneyRequest request);
    }
}
