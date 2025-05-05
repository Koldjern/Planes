using SubDomain.Events;
using SubDomain.Models;

namespace PeopleDomain.PassengerAggregate.Events;

public record PassengerDeleted : DeleteEvent<Passenger>
{
	public PassengerDeleted(Passenger Deleted)
		: base(Deleted)
	{
	}
}
