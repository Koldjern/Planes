using ErrorOr;
using MediatR;
using PeopleDomain.PassengerAggregate;

namespace PeopleApplication.Passengers.Commands.Update;

public class UpdatePassengerCommandHandler : IRequestHandler<UpdatePassengerCommand, ErrorOr<Updated>>
{
	private readonly IPassengerRepository _repository;

	public UpdatePassengerCommandHandler(IPassengerRepository repository)
	{
		_repository = repository;
	}

	public async Task<ErrorOr<Updated>> Handle(UpdatePassengerCommand request, CancellationToken cancellationToken)
	{
		var passenger = await _repository.Get(request.Id);

		if (passenger is null)
			return Errors.Passenger.NotFound;

		passenger.Weight = request.Weight;

		var updated = await _repository.Update(passenger);

		if (!updated)
			return Errors.Passenger.CantUpdate;
		return Result.Updated;
	}
}
