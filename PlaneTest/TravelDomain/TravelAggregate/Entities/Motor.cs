using SubDomain.Models;

namespace TravelDomain.TravelAggregate.Entities;

public class Motor : ValueObject
{
	private Motor(double power, double consumption)
	{
		Power = power;
		Consumption = consumption;
	}
	public double Power { get; }
	public double Consumption { get; }
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
}
