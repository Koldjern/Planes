using PlaneDomain.PlaneAggregate;
namespace PlaneApplication.Planes;

public interface IPlaneRepository
{
	Task<bool> Add(Plane plane);
	Task<bool> Delete(Guid id);
	Task<bool> Update(Plane plane);
	Task<Plane?> Get(Guid id);
	Task<IEnumerable<Plane>> GetAll();
}
