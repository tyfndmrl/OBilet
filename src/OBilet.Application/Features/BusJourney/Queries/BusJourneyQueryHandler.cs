using Mapster;
using OBilet.Application.Common.Interfaces;
using OBilet.Application.Common.Models;
using OBilet.Application.Messaging;
using OBilet.Application.Services;
using OBilet.Application.Services.Models.Request;

namespace OBilet.Application.Features.BusJourney.Queries
{
    public class BusJourneyQueryHandler : IQueryHandler<BusJourneyQuery, List<BusJourneyDto>>
    {
        private readonly IOBiletService _oBiletService;
        private readonly ICurrentUser _currentUser;

        public BusJourneyQueryHandler(IOBiletService service, ICurrentUser currentUser)
        {
            _oBiletService = service;
            _currentUser = currentUser;
        }

        public async Task<IResult<List<BusJourneyDto>>> Handle(BusJourneyQuery request, CancellationToken cancellationToken)
        {
            var oBiletRequest = request.Adapt<BusJourneyRequest>();
            var response = await _oBiletService.GetBusJourneyAsync(oBiletRequest);

            if (response == null) {
                return Result.Fail<List<BusJourneyDto>>("Failed to get bus journey");
            }
            else if (response.Status != "Success") {
                return Result.Fail<List<BusJourneyDto>>(response.UserMessage);
            }

            var result = response.Data.Adapt<List<BusJourneyDto>>();
            return Result.Ok(result);
        }
    }
}
