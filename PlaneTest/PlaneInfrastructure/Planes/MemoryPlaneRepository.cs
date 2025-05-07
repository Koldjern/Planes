using System.Reflection;
using PlaneApplication.Planes;
using PlaneDomain.PlaneAggregate;
using PlaneDomain.PlaneAggregate.Entities;
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

				IdSetter(newPlane, plane.Id);

				newPlane.ClearDomainEvents();

				return newPlane;
			},
			(plane) => new PlaneDeleted(plane),
			(after, before) => new PlaneUpdated(after, before))
		{
		if (_entities is null)
		{
			List<Guid> ids = new List<Guid>([
				Guid.Parse("5535ae79-426f-49ec-96b7-b4212373474e"),
				Guid.Parse("8410afe4-0364-4958-911d-a2d07b195818"),
				Guid.Parse("3e3794a6-f562-4b71-a6e4-202061e82403"),
				Guid.Parse("676f40c2-04a4-4b0f-8c3b-bf23b4096428")]);

			_entities = new List<Plane>([
				Plane.CreateNew(PlaneType.Glider, null, 400, 600, "Glider Tester", 100),
				Plane.CreateNew(PlaneType.TransportPlane, Motor.CreateNew("Transport Motor", 120000, 7.5), 210000, 250000, "Transport Tester", 850),
				Plane.CreateNew(PlaneType.JetFighter, Motor.CreateNew("Jet Motor", 40000, 3.5), 20000, 30000, "Jet Fighter Tester", 1000),
				Plane.CreateNew(PlaneType.PassengerPlane, Motor.CreateNew("Passenger Motor", 60000, 5.5), 40000, 50000, "PassengerPlane Tester", 700)]);

			_entities.ForEach(p => IdSetter(p, ids[_entities.IndexOf(p)]));
		}
	}
}
