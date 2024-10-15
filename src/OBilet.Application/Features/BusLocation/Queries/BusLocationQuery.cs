using OBilet.Application.Messaging;

namespace OBilet.Application.Features.BusLocation.Queries
{
    public class BusLocationQuery : IQuery<List<BusLocationDto>>
    {
        public string? Search { get; set; }
    }
}
