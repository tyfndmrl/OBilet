using Mapster;
using OBilet.Application.Common.Interfaces;
using OBilet.Application.Common.Models;
using OBilet.Application.Messaging;
using OBilet.Application.Services;
using OBilet.Application.Services.Models.Request;

namespace OBilet.Application.Features.Session.Queries
{
    public class SessionQueryHandler : IQueryHandler<SessionQuery, SessionDto>
    {
        private readonly IOBiletService _oBiletService;
        private readonly ICurrentUser _currentUser;

        public SessionQueryHandler(IOBiletService service, ICurrentUser currentUser)
        {
            _oBiletService = service;
            _currentUser = currentUser;
        }

        public async Task<IResult<SessionDto>> Handle(SessionQuery request, CancellationToken cancellationToken)
        {
            var oBiletRequest = request.Adapt<SessionRequest>();
            var response = await _oBiletService.GetSessionAsync(oBiletRequest);
            
            if (response == null) {
                return Result.Fail<SessionDto>("Failed to get session");
            }
            else if (response.Status != "Success") {
                return Result.Fail<SessionDto>(response.UserMessage);
            }

            var result = response.Data.Adapt<SessionDto>();
            return Result.Ok(result);
        }
    }
}
