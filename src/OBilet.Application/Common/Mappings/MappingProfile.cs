using Mapster;
using OBilet.Application.Features.BusJourney.Queries;
using OBilet.Application.Features.BusLocation.Queries;
using OBilet.Application.Features.Session.Queries;
using OBilet.Application.Services.Models.Request;
using OBilet.Application.Services.Models.Response;

namespace OBilet.Application.Common.Mappings
{
    public static class MappingProfile
    {
        public static void Map()
        {
            TypeAdapterConfig<BusLocationQuery, BusLocationRequest>
                .NewConfig()
                .Map(dest => dest.Data, src => src.Search)
                .Map(dest => dest.Date, src => DateTime.Now)
                .Map(dest => dest.Language, src => "tr-TR");

            TypeAdapterConfig<BusLocationResponse, BusLocationDto>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name);


            TypeAdapterConfig<BusJourneyQuery, BusJourneyRequest>
                .NewConfig()
                .Map(dest => dest.Data.DepartureDate, src => src.DepartureDate.ToString("yyyy-MM-dd"))
                .Map(dest => dest.Data.OriginId, src => src.OriginId)
                .Map(dest => dest.Data.DestinationId, src => src.DestinationId)
                .Map(dest => dest.Date, src => DateTime.Now)
                .Map(dest => dest.Language, src => "tr-TR");

            TypeAdapterConfig<BusJourneyResponse, BusJourneyDto>
                .NewConfig()
                .Map(dest => dest.ArrivalTime, src => src.Journey.Arrival)
                .Map(dest => dest.DepartureTime, src => src.Journey.Departure)
                .Map(dest => dest.Origin, src => src.Journey.Origin)
                .Map(dest => dest.Destination, src => src.Journey.Destination)
                .Map(dest => dest.Price, src => src.Journey.OriginalPrice);


            TypeAdapterConfig<SessionQuery, SessionRequest>
                .NewConfig()
                .Map(dest => dest.Type, src => 1)
                .Map(dest => dest.Browser.Name, src => src.BrowserName)
                .Map(dest => dest.Browser.Version, src => src.BrowserVersion)
                .Map(dest => dest.Connection.IpAddress, src => src.IpAddress)
                .Map(dest => dest.Connection.Port, src => src.Port);

            TypeAdapterConfig<SessionResponse, SessionDto>
                .NewConfig()
                .Map(dest => dest.SessionId, src => src.SessionId)
                .Map(dest => dest.DeviceId, src => src.DeviceId);
        }
    }
}
