using SubDomain.Events;

namespace PlaneDomain.PlaneAggregate.Events;

public record PlaneDeleted : DeleteEvent<Plane>
{
	public PlaneDeleted(Plane Deleted)
		: base(Deleted)
	{
	}
}
