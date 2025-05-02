using SubDomain.Models;

namespace SubDomain.Events;

public abstract record UpdateEvent<T>(T Before, T After)
	: IDomainEvent;