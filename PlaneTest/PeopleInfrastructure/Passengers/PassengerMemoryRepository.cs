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

				IdSetter(newPassenger, passenger.Id);

				newPassenger.ClearDomainEvents();

				return newPassenger;
			},
			(passenger) => new PassengerDeleted(passenger),
			(before, after) => new PassengerUpdated(before, after))
	{
		if (_entities is null)
		{
			List<Guid> ids = new List<Guid>([Guid.Parse("5535ae79-426f-49ec-96b7-b4212373474e"), Guid.Parse("8410afe4-0364-4958-911d-a2d07b195818"), Guid.Parse("125f3ba7-8cdc-4d25-8ab3-9507ecfd8fae")]);
			_entities = new List<Passenger>([Passenger.CreateNew(100), Passenger.CreateNew(80), Passenger.CreateNew(120)]);
			_entities.ForEach(p => IdSetter(p, ids[_entities.IndexOf(p)]));
		}
	}
}
