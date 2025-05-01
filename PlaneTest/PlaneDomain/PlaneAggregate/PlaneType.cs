namespace PlaneDomain.PlaneAggregate;

public static class PlaneType
{
	public const string Glider = "Glider";
	public const string PrivatePlane = "PrivatePlane";
	public const string PassengerPlane = "PassengerPlane";
	public const string TransportPlane = "TransportPlane";
	public const string JetFighter = "JetFighter";

	public static bool BeAValidPlaneType(string type)
	{
		return type == PlaneType.Glider ||
			   type == PlaneType.PrivatePlane ||
			   type == PlaneType.PassengerPlane ||
			   type == PlaneType.TransportPlane ||
			   type == PlaneType.JetFighter;
	}

	public static bool IsGlider(string type)
	{
		return string.Equals(type, PlaneType.Glider, StringComparison.OrdinalIgnoreCase);
	}
}
