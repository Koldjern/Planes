using SubDomain.Models;

namespace PeopleDomain.PassengerAggregate.Events;

public record PassengerUpdated(Passenger Passenger)
	: IDomainEvent;