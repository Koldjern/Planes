using TravelDomain.TravelAggregate;
using TravelDomain.TravelAggregate.Entities.Planes;

namespace TravelApplication.Travels.Responses;

public record DistanceResponse(string Type, double DistancePerHour, double Amount)
{
	public static DistanceResponse KmOrMiles(string? kmOrMiles, Travel travel, TravelPlane plane)
	{
		if (kmOrMiles == null)
			return new DistanceResponse("Km", plane.SpeedKm(), travel.DistanceKM());

		if (kmOrMiles.ToLower().Contains("mile"))
			return new DistanceResponse("Mile", plane.SpeedMiles(), travel.DistanceMiles());

		return new DistanceResponse("Km", plane.SpeedKm(), travel.DistanceKM());
	}
}
