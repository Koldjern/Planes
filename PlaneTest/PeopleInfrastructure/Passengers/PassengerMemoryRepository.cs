using PeopleApplication.Passengers;
using PeopleDomain.PassengerAggregate;
using SubInfrastructure;

namespace PeopleInfrastructure.Passengers;

public class MemoryPassengerRepository : CrudMemory<Passenger, Guid>, IPassengerRepository
{
	public MemoryPassengerRepository(DomainEventPublishingMemory publisher)
		: base(publisher)
	{
	}
}
