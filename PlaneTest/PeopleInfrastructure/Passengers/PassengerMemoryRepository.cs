using System.Reflection;
using PeopleApplication.Passengers;
using PeopleDomain.PassengerAggregate;
using PeopleDomain.PassengerAggregate.Events;
using SubInfrastructure;

namespace PeopleInfrastructure.Passengers;

public class MemoryPassengerRepository : CrudMemory<Passenger, Guid>, IPassengerRepository
{
	public MemoryPassengerRepository(DomainEventPublishingMemory publisher)
		: base(
			publisher,
			(passenger) =>
			{
				var newPassenger = Passenger.CreateNew(passenger.Weight);

				var idProp = typeof(Passenger).GetProperty("Id", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy);
				if (idProp != null && idProp.CanWrite)
				{
					idProp.SetValue(newPassenger, passenger.Id);
				}

				newPassenger.ClearDomainEvents();

				return newPassenger;
			},
			(passenger) => new PassengerDeleted(passenger),
			(before, after) => new PassengerUpdated(before, after))
	{
	}
}
