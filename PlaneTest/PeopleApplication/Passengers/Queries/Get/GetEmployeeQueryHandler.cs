using ErrorOr;
using MediatR;
using PeopleDomain.PassengerAggregate;

namespace PeopleApplication.Passengers.Queries.Get;

public class GetPassengerQueryHandler : IRequestHandler<GetPassengerQuery, ErrorOr<Passenger>>
{
	private readonly IPassengerRepository _repository;

	public GetPassengerQueryHandler(IPassengerRepository repository)
	{
		_repository = repository;
	}

	public async Task<ErrorOr<Passenger>> Handle(GetPassengerQuery request, CancellationToken cancellationToken)
	{
		var find = await _repository.Get(request.Id);
		if (find is null)
			return Errors.Passenger.NotFound;
		return find;
	}
}
