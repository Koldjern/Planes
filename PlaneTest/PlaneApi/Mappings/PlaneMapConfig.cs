using Mapster;
using PlaneApi.Contracts;
using PlaneApplication.Planes.Commands.Add;
using PlaneApplication.Planes.Commands.Update;
using PlaneDomain.PlaneAggregate;
using PlaneDomain.PlaneAggregate.Entities;

namespace PlaneApi.Mappings;

public class PlaneMapConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<IEnumerable<Plane>, PlanesResponse>()
			.Map(dest => dest.Planes, src => src);
	}
}