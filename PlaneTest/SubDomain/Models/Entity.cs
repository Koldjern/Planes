using MediatR;

namespace SubDomain.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>, IHasDomainEvent
	where TId : notnull
{
	private readonly List<INotification> _domainEvents = new ();
	protected Entity(TId id)
	{
		Id = id;
	}

	public TId Id { get; protected set; }

	public IReadOnlyList<INotification> DomainEvents => _domainEvents.AsReadOnly();

	public static bool operator ==(Entity<TId> left, Entity<TId> right)
	{
		return Equals(left, right);
	}
	public static bool operator !=(Entity<TId> left, Entity<TId> right)
	{
		return !Equals(left, right);
	}

	public override bool Equals(object? obj)
	{
		return obj?.GetType() == GetType() && Id.Equals(((Entity<TId>)obj).Id);
	}

	public override int GetHashCode()
	{
		return Id.GetHashCode();
	}

	public void AddDomainEvent(INotification domainEvent)
	{
		_domainEvents.Add(domainEvent);
	}

	public bool Equals(Entity<TId>? other)
	{
		return Equals((object?)other);
	}

	public void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}
}
