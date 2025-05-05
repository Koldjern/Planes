using PeopleDomain.PassengerAggregate.Events;
using SubDomain.Models;

namespace PeopleDomain.PassengerAggregate;

public class Passenger : AggregateRoot<Guid>
{
	private Passenger(Guid id, double weight)
		: base(id)
	{
		Weight = weight;
	}

	public double Weight { get; set; }

	public static Passenger CreateNew(double weight)
	{
		Passenger passenger = new Passenger(Guid.NewGuid(), weight);
		passenger.AddDomainEvent(new PassengerAdded(passenger));

		return passenger;
	}

	public override string ToString()
	{
		return $"Weight: {Weight}";
	}
#pragma warning disable CS8618, SA1201
	private Passenger()
	{
	}
#pragma warning restore CS8618, SA1201
}
