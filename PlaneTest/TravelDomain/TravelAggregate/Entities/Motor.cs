using SubDomain.Models;

namespace TravelDomain.TravelAggregate.Entities;

public class Motor : ValueObject
{
	private Motor(double power, double consumption)
	{
		Power = power;
		Consumption = consumption;
	}
	public double Power { get; private set; }
	public double Consumption { get; private set; }
	public static Motor Create(double power, double consumption)
	{
		return new (power, consumption);
	}

	public override IEnumerable<object> GetEqualityComponents()
	{
		return [Power, Consumption];
	}

	public override string ToString()
	{
		return $"Power: {Power}, Consumption: {Consumption}";
	}
#pragma warning disable CS8618, SA1201
	private Motor()
	{
	}
#pragma warning restore CS8618, SA1201
}