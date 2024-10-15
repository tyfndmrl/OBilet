using Mapster;
using OBilet.Application.Common.Interfaces;
using OBilet.Application.Common.Models;
using OBilet.Application.Features.BusJourney.Queries;
using OBilet.Application.Messaging;
using OBilet.Application.Services;
using OBilet.Application.Services.Models.Request;

namespace OBilet.Application.Features.BusLocation.Queries
{
    public class BusLocationQueryHandler : IQueryHandler<BusLocationQuery, List<BusLocationDto>>
    {
        private readonly IOBiletService _oBiletService;
        private readonly ICurrentUser _currentUser;

        public BusLocationQueryHandler(IOBiletService service)
        {
            _oBiletService = service;
        }

        public async Task<IResult<List<BusLocationDto>>> Handle(BusLocationQuery request, CancellationToken cancellationToken)
        {
            var oBiletRequest = request.Adapt<BusLocationRequest>();
            var response = await _oBiletService.GetBusLocationAsync(oBiletRequest);

            if (response == null) {
                return Result.Fail<List<BusLocationDto>>("Failed to get bus location");
            }
            else if (response.Status != "Success") {
                return Result.Fail<List<BusLocationDto>>(response.UserMessage);
            }

            var result = response.Data.Adapt<List<BusLocationDto>>();
            return Result.Ok(result);
        }
    }
}
