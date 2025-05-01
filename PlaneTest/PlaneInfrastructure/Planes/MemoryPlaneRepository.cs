using PlaneApplication.Planes;
using PlaneDomain.PlaneAggregate;
using SubInfrastructure;

namespace PlaneInfrastructure.Planes;

public class MemoryPlaneRepository : IPlaneRepository
{
	private static List<Plane> _planes = new List<Plane>();
	private readonly DomainEventPublishingMemory _publisher;

	public MemoryPlaneRepository(DomainEventPublishingMemory publisher)
	{
		_publisher = publisher;
	}

	public async Task<bool> Add(Plane plane)
	{
		await Task.CompletedTask;
		_planes.Add(plane);
		await _publisher.PublishDomainEvents(plane);
		return true;
	}

	public async Task<bool> Delete(Guid id)
	{
		await Task.CompletedTask;
		var find = _planes.Find(x => x.Id == id);

		if (find is null)
			return false;

		_planes.Remove(find);
		return true;
	}

	public async Task<Plane?> Get(Guid id)
	{
		await Task.CompletedTask;
		return _planes.Find(x => x.Id == id);
	}

	public async Task<IEnumerable<Plane>> GetAll()
	{
		await Task.CompletedTask;
		return _planes.ToList();
	}

	public async Task<bool> Update(Plane plane)
	{
		await Task.CompletedTask;
		var find = _planes.Find(x => x.Id == plane.Id);

		if (find is null)
			return false;

		_planes.Remove(find);
		_planes.Add(plane);
		return true;
	}
}
