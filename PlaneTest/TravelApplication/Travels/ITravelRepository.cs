using TravelDomain.TravelAggregate;

namespace TravelApplication.Travels;

public interface ITravelRepository
{
	Task<bool> Add(Travel entity);

	Task<Travel?> Get(Guid id);
}
