using SubDomain.Models;
using TravelDomain.TravelAggregate.Entities.Employee;

namespace TravelDomain.TravelAggregate.Entities.People;

public class TravelPassenger : Entity<Guid>
{
	private TravelPassenger(Guid id, double weight)
		: base(id)
	{
		Weight = weight;
	}

	public double Weight { get; set; }
	public static TravelPassenger Create(Guid id, double weight)
	{
		return new TravelPassenger(id, weight);
	}
}
