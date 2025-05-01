using PlaneDomain.PlaneAggregate.Entities;
using PlaneDomain.PlaneAggregate.Events;
using SubDomain.Models;

namespace PlaneDomain.PlaneAggregate;

public class Plane : AggregateRoot<Guid>
{
	private Plane(Guid id, string type, Motor? motor, double weightKg, double maxWeight, string name, double maxSpeed)
		: base(id)
	{
		Type = type;
		Motor = motor;
		WeightKg = weightKg;
		MaxWeight = maxWeight;
		Name = name;
		MaxSpeed = maxSpeed;
	}

	// Motor can still be exchanged in a ex /Plane/NewMotor
	public Motor? Motor { get; set; }
	public double WeightKg { get; set; }
	public double MaxWeight { get; set; }
	public string Name { get; set; }
	public double MaxSpeed { get; set; }
	public string Type { get; set; }

	public static Plane CreateNew(string type, Motor? motor, double weightKg, double maxWeight, string name, double maxSpeed)
	{
		Plane plane = new Plane(Guid.NewGuid(), type, motor, weightKg, maxWeight, name, maxSpeed);

		plane.AddDomainEvent(new PlaneAdded(plane));

		return plane;
	}

	public void UpdateMotor(string name, double power, double consumption)
	{
		Motor = Motor.Update(Motor!.Id, name, power, consumption);
	}
}
