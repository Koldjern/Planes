using SubDomain.Events;
using SubDomain.Models;

namespace SubInfrastructure;

public abstract class CrudMemory<TRoot, TId>
	where TRoot : AggregateRoot<TId>
	where TId : notnull
{
	private static List<TRoot> _entities = new List<TRoot>();
	private readonly DomainEventPublishingMemory _publisher;
	private readonly Func<TRoot, DeleteEvent<TRoot>>? _deleteEvent;
	private readonly Func<TRoot, TRoot, UpdateEvent<TRoot>>? _updateEvent;
	private readonly Func<TRoot, TRoot> _copy;

	public CrudMemory(
		DomainEventPublishingMemory publisher,
		Func<TRoot, TRoot> copy,
		Func<TRoot, DeleteEvent<TRoot>>? deleteEvent = null,
		Func<TRoot, TRoot, UpdateEvent<TRoot>>? updateEvent = null)
	{
		_copy = copy;
		_publisher = publisher;
		_deleteEvent = deleteEvent;
		_updateEvent = updateEvent;
	}

	public async Task<bool> Add(TRoot entity)
	{
		await Task.CompletedTask;
		_entities.Add(entity);
		await _publisher.PublishDomainEvents(entity);
		return true;
	}

	public async Task<bool> Delete(TId id)
	{
		await Task.CompletedTask;
		var find = _entities.Find(x => x.Id.Equals(id));

		if (find is null)
			return false;

		_entities.Remove(find);
		if (_deleteEvent != null)
			find.AddDomainEvent(_deleteEvent(find));

		await _publisher.PublishDomainEvents(find);
		return true;
	}

	public async Task<TRoot?> Get(Guid id)
	{
		await Task.CompletedTask;
		var find = _entities.Find(x => x.Id.Equals(id));
		if (find is not null)
			return _copy(find);
		return find;
	}

	public async Task<IEnumerable<TRoot>> GetAll()
	{
		await Task.CompletedTask;
		return _entities.ToList();
	}

	public async Task<bool> Update(TRoot entity)
	{
		await Task.CompletedTask;
		var find = _entities.Find(x => x.Id.Equals(entity.Id));

		if (find is null)
			return false;

		_entities.Remove(find);
		_entities.Add(entity);

		if (_updateEvent != null)
			find.AddDomainEvent(_updateEvent(find, entity));

		await _publisher.PublishDomainEvents(find);
		return true;
	}
}
