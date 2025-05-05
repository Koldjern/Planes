using SubDomain.Events;
using SubDomain.Models;

namespace PeopleDomain.PassengerAggregate.Events;

public record PassengerUpdated : UpdateEvent<Passenger>
{
	public PassengerUpdated(Passenger Before, Passenger After)
		: base(Before, After)
	{
	}
}
