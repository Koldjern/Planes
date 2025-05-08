using TravelDomain.TravelAggregate;
using TravelDomain.TravelAggregate.Entities.Planes;

namespace TravelApplication.Travels.Responses;

public record DistanceResponse(string Type, double DistancePerHour, double Amount)
{
	public static DistanceResponse KmOrMiles(string? kmOrMiles, Travel travel)
	{
		if (kmOrMiles == null)
			return new DistanceResponse("Km", travel.SpeedKm(), travel.DistanceKM());

		if (kmOrMiles.ToLower().Contains("mile"))
			return new DistanceResponse("Mile", travel.SpeedMiles(), travel.DistanceMiles());

		return new DistanceResponse("Km", travel.SpeedKm(), travel.DistanceKM());
	}
}
