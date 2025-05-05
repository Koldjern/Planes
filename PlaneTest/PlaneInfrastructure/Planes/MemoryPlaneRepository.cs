using System.Reflection;
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
			(plane) =>
			{
				var newPlane = Plane.CreateNew(plane.Type, plane.Motor, plane.WeightKg, plane.MaxWeight, plane.Name, plane.MaxSpeed);

				var idProp = typeof(Plane).GetProperty("Id", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy);
				if (idProp != null && idProp.CanWrite)
				{
					idProp.SetValue(newPlane, plane.Id);
				}

				newPlane.ClearDomainEvents();

				return newPlane;
			},
			(plane) => new PlaneDeleted(plane),
			(after, before) => new PlaneUpdated(after, before))
	{
	}
}
