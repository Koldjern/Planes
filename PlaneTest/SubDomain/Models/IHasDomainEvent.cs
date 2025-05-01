using MediatR;

namespace SubDomain.Models;

public interface IHasDomainEvent
{
	public IReadOnlyList<INotification> DomainEvents { get; }
	public void ClearDomainEvents();
}
