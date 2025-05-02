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
		return new Passenger(Guid.NewGuid(), weight);
	}
}
