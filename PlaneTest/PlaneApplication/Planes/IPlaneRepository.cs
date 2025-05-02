using PlaneDomain.PlaneAggregate;
using SubApplication;
namespace PlaneApplication.Planes;

public interface IPlaneRepository : ICrud<Plane, Guid>
{
}
