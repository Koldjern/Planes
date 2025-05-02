using SubDomain.Models;

namespace PeopleDomain.PassengerAggregate.Events;

public record PassengerDeleted(Passenger Passenger)
	: IDomainEvent;
