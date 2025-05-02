using SubDomain.Models;

namespace PeopleDomain.EmployeeAggregate.Events;

public record EmployeeDeleted(Employee Employee)
	: IDomainEvent;
