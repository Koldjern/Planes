using SubDomain.Models;

namespace TravelDomain.TravelAggregate.ValueObjects;

public class Coordinate : ValueObject
{
	public double Latitude { get; private set; }
	public double Longitude { get; private set; }

	public Coordinate(double latitude, double longitude)
	{
		Latitude = latitude;
		Longitude = longitude;
	}

	public static double DistanceMeters(Coordinate from, Coordinate to)
	{
		const double r = 6378100; // meters

		var sdlat = Math.Sin((to.Latitude - from.Latitude) / 2);
		var sdlon = Math.Sin((to.Longitude - from.Longitude) / 2);
		var q = sdlat * sdlat + Math.Cos(from.Latitude) * Math.Cos(to.Latitude) * sdlon * sdlon;
		var d = 2 * r * Math.Asin(Math.Sqrt(q));

		return d;
	}
	public override IEnumerable<object> GetEqualityComponents()
	{
		return [Latitude, Longitude];
	}
}
