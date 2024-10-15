namespace OBilet.Application.Services.Configurations
{
    public class OBiletConfiguration
    {
        public const string ServiceName = "OBilet";
        public string BaseUrl { get; set; }
        public string AuthenticationScheme { get; set; }
        public string Token { get; set; }
        public string GetLocationUrl { get; set; }
        public string GetJourneyUrl { get; set; }
        public string GetSessionUrl { get; set; }
    }
}
