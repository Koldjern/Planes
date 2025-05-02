using SubDomain.Models;

namespace PeopleDomain.PassengerAggregate.Events;

public record PassengerAdded(Passenger Passenger)
	: IDomainEvent;
