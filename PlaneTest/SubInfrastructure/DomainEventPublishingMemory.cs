using MediatR;
using SubDomain.Models;

namespace SubInfrastructure;

public class DomainEventPublishingMemory
{
	private readonly IPublisher _mediator;

	public DomainEventPublishingMemory(IPublisher mediator)
	{
		_mediator = mediator;
	}

	public async Task PublishDomainEvents(IHasDomainEvent holder)
	{
		var events = holder.DomainEvents.ToList();
		holder.ClearDomainEvents();

		foreach (var domainEvent in events)
			await _mediator.Publish(domainEvent);
	}
}
