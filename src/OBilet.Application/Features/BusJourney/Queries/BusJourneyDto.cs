namespace OBilet.Application.Features.BusJourney.Queries
{
    public class BusJourneyDto
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
    }
}
