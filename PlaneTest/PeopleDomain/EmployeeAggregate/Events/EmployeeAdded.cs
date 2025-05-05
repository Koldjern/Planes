using SubDomain.Models;

namespace PeopleDomain.EmployeeAggregate.Events;

public record EmployeeAdded(Employee Employee)
	: IDomainEvent;
