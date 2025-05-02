using SubDomain.Events;
using SubDomain.Models;

namespace PlaneDomain.PlaneAggregate.Events;

public record PlaneUpdated : UpdateEvent<Plane>
{
	public PlaneUpdated(Plane Before, Plane After)
		: base(Before, After)
	{
	}
}
