using ErrorOr;
using MediatR;
using PeopleDomain.PassengerAggregate;

namespace PeopleApplication.Passengers.Commands.Delete;

public class DeletePassengerCommandHandler : IRequestHandler<DeletePassengerCommand, ErrorOr<Deleted>>
{
	private readonly IPassengerRepository _repository;

	public DeletePassengerCommandHandler(IPassengerRepository repository)
	{
		_repository = repository;
	}

	public async Task<ErrorOr<Deleted>> Handle(DeletePassengerCommand request, CancellationToken cancellationToken)
	{
		var find = await _repository.Get(request.Id);
		if (find is null)
			return Errors.Passenger.NotFound;

		var deleted = await _repository.Delete(request.Id);

		if (!deleted)
			return Errors.Passenger.CantDelete;

		return Result.Deleted;
	}
}
