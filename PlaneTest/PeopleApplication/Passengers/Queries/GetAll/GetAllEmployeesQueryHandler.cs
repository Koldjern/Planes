using ErrorOr;
using MediatR;
using PeopleDomain.PassengerAggregate;

namespace PeopleApplication.Passengers.Queries.GetAll;

public class GetAllPassengersQueryHandler
	: IRequestHandler<GetAllPassengersQuery, ErrorOr<IEnumerable<Passenger>>>
{
	private readonly IPassengerRepository _repository;

	public GetAllPassengersQueryHandler(IPassengerRepository repository)
	{
		_repository = repository;
	}

	public async Task<ErrorOr<IEnumerable<Passenger>>> Handle(GetAllPassengersQuery request, CancellationToken cancellationToken)
	{
		var planes = await _repository.GetAll();
		return planes.ToErrorOr();
	}
}
