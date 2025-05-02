using PlaneApplication.Planes;
using PlaneDomain.PlaneAggregate;
using PlaneDomain.PlaneAggregate.Events;
using SubInfrastructure;

namespace PlaneInfrastructure.Planes;

public class MemoryPlaneRepository : CrudMemory<Plane, Guid>, IPlaneRepository
{
	public MemoryPlaneRepository(DomainEventPublishingMemory publisher)
		: base(
			publisher,
			(plane) => new PlaneDeleted(plane),
			(after, before) => new PlaneUpdated(after, before))
	{
	}
}
