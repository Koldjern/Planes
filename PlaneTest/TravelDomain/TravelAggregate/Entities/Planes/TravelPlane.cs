using SubDomain.Models;
using TravelDomain.TravelAggregate.Entities.Employee;
using TravelDomain.TravelAggregate.Entities.People;

namespace TravelDomain.TravelAggregate.Entities.Planes;

public abstract class TravelPlane : Entity<Guid>
{
	protected TravelPlane(
		Guid id,
		Motor? motor,
		double weightKg,
		double maxWeight,
		string name,
		double maxSpeed,
		IEnumerable<TravelEmployee> employees,
		IEnumerable<TravelPassenger> passengers)
		: base(id)
	{
		Motor = motor;
		WeightKg = weightKg;
		MaxWeight = maxWeight;
		Name = name;
		MaxSpeed = maxSpeed;
		Employees = employees;
		Passengers = passengers;
	}
	public IEnumerable<TravelEmployee> Employees { get; set; }
	public IEnumerable<TravelPassenger> Passengers { get; set; }
	public Motor? Motor { get; set; }
	public double WeightKg { get; set; }
	public double MaxWeight { get; set; }
	public string Name { get; set; }
	public double MaxSpeed { get; set; }

	public virtual double SpeedKm()
	{
		// using constant from simple example
		double speed = 1606.9 * (Motor!.Power * Weight());
		return speed > MaxSpeed ? MaxSpeed : speed;
	}

	public virtual double Weight()
	{
		var employeesWeight = Employees.Sum(e => e.Weight);
		var passengersWeight = Passengers.Sum(e => e.Weight);
		return WeightKg + employeesWeight + passengersWeight;
	}
}
