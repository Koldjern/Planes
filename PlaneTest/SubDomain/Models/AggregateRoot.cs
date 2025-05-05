namespace SubDomain.Models;

public abstract class AggregateRoot<TId> : Entity<TId>
	where TId : notnull
{
	protected AggregateRoot(TId id)
		: base(id)
	{
	}
#pragma warning disable CS8618, SA1201
	protected AggregateRoot()
	{
	}
#pragma warning restore CS8618, SA1201
}
