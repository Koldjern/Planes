using SubDomain.Events;
using SubDomain.Models;

namespace PlaneDomain.PlaneAggregate.Events;

public record PlaneDeleted : DeleteEvent<Plane>
{
	public PlaneDeleted(Plane Deleted)
		: base(Deleted)
	{
	}
}
