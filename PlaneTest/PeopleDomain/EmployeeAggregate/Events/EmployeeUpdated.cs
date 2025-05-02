using SubDomain.Models;

namespace PeopleDomain.EmployeeAggregate.Events;

public record EmployeeUpdated(Employee Employee)
	: IDomainEvent;
