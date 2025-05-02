using Mapster;
using PeopleApi.Contracts.Passenger;
using PeopleDomain.PassengerAggregate;

namespace PeopleApi.Mappings;

public class PassengerMapConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<IEnumerable<Passenger>, PassengersResponse>()
			.Map(dest => dest.Passengers, src => src);
	}
}
