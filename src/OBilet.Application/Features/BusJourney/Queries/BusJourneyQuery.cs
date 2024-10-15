using OBilet.Application.Messaging;

namespace OBilet.Application.Features.BusJourney.Queries
{
    public class BusJourneyQuery : IQuery<List<BusJourneyDto>>
    {
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
