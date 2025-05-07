using TravelDomain.TravelAggregate.Entities.Employee;
using TravelDomain.TravelAggregate.Entities.People;

namespace TravelDomain.TravelAggregate.Entities.Planes;

public class PassengerPlane : TravelPlane
{
	private PassengerPlane(Guid id, Motor motor, double weightKg, double maxWeight, string name, double maxSpeed, IEnumerable<TravelEmployee> employees, IEnumerable<TravelPassenger> passengers)
	: base(id, motor, weightKg, maxWeight, name, maxSpeed, employees, passengers)
	{
	}

	public static PassengerPlane Create(Guid id, Motor motor, double weightKg, double maxWeight, string name, double maxSpeed, IEnumerable<TravelEmployee> employees, IEnumerable<TravelPassenger> passengers)
	{
		var plane = new PassengerPlane(id, motor, weightKg, maxWeight, name, maxSpeed, employees, passengers);
		return plane;
	}
}
