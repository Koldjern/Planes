using SubDomain.Models;

namespace TravelDomain.TravelAggregate.Events;

public record TravelEnded(Travel Travel)
	: IDomainEvent;