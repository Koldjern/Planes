using SubDomain.Models;

namespace PlaneDomain.PlaneAggregate.Events;

public record PlaneAdded(Plane Plane)
	: IDomainEvent;