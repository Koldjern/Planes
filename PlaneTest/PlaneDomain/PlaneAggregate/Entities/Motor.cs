using SubDomain.Models;

namespace PlaneDomain.PlaneAggregate.Entities;

public class Motor : Entity<Guid>
{
	private Motor(Guid id, string name, double power, double consumption)
		: base(id)
	{
		Name = name;
		Power = power;
		Consumption = consumption;
	}
	public string Name { get; }
	public double Power { get; }
	public double Consumption { get; }
	public static Motor CreateNew(string name, double power, double consumption)
	{
		return new (Guid.NewGuid(), name, power, consumption);
	}
	public static Motor Update(Guid id, string name, double power, double consumption)
	{
		return new (id, name, power, consumption);
	}
}
