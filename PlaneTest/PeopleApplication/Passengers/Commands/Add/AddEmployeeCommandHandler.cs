using ErrorOr;
using MediatR;
using PeopleDomain.PassengerAggregate;

namespace PeopleApplication.Passengers.Commands.Add;

public class AddPassengerCommandHandler : IRequestHandler<AddPassengerCommand, ErrorOr<Guid>>
{
	private readonly IPassengerRepository _repository;

	public AddPassengerCommandHandler(IPassengerRepository repository)
	{
		_repository = repository;
	}

	public async Task<ErrorOr<Guid>> Handle(AddPassengerCommand request, CancellationToken cancellationToken)
	{
		var passenger = Passenger.CreateNew(request.Weight);
		var added = await _repository.Add(passenger);

		if (!added)
			return Errors.Passenger.CantAdd;

		return passenger.Id;
	}
}
