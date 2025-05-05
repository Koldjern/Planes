using TravelDomain.TravelAggregate.Entities.Employee;
using TravelDomain.TravelAggregate.Entities.People;

namespace TravelDomain.TravelAggregate.Entities.Planes;

public class GliderPlane : TravelPlane
{
	private GliderPlane(Guid id, double weightKg, double maxWeight, string name, double maxSpeed, double launchSpeed, TravelEmployee captain, TravelPassenger? passenger)
		: base(id, null, weightKg, maxWeight, name, maxSpeed, [captain], passenger is null ? [] : [passenger])
	{
		LaunchSpeed = launchSpeed;
	}
	public double LaunchSpeed { get; set; }

	public static GliderPlane Create(Guid id, double weightKg, double maxWeight, string name, double maxSpeed, double launchSpeed, TravelEmployee captain, TravelPassenger? passenger)
	{
		var plane = new GliderPlane(id, weightKg, maxWeight, name, maxSpeed, launchSpeed, captain, passenger);
		return plane;
	}

	public override double SpeedKm()
	{
		return LaunchSpeed;
	}
}
