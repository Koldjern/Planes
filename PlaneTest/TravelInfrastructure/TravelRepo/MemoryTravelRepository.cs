using SubInfrastructure;
using TravelApplication.Travels;
using TravelDomain.TravelAggregate;

namespace TravelInfrastructure.TravelRepo;

public class MemoryTravelRepository : ITravelRepository
{
	private static List<Travel> _travels = new List<Travel>();
	private readonly DomainEventPublishingMemory _publisher;

	public MemoryTravelRepository(DomainEventPublishingMemory publisher)
	{
		_publisher = publisher;
	}

	public async Task<bool> Add(Travel entity)
	{
		await Task.CompletedTask;
		_travels.Add(entity);
		await _publisher.PublishDomainEvents(entity);
		return true;
	}

	public async Task<Travel?> Get(Guid id)
	{
		await Task.CompletedTask;
		var find = _travels.Find(x => x.Id.Equals(id));
		return find;
	}
}
