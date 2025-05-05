using TravelApplication.Travels.Responses;

namespace TravelApplication.Travels;

public interface IPlanesApi
{
	Task<PlaneResponse?> GetPlane(Guid id);
}
