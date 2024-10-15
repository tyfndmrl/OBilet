namespace OBilet.Application.Common.Interfaces
{
    public interface ICurrentUser
    {
        string SessionId { get; }
        string DeviceId { get; }
    }
}
