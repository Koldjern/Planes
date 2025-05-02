using SubDomain.Models;

namespace SubDomain.Events;

public record DeleteEvent<T>(T Deleted)
	: IDomainEvent;
