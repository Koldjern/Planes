using ErrorOr;
using MediatR;

namespace PeopleApplication.Passengers.Commands.Delete;

public record DeletePassengerCommand(Guid Id)
	: IRequest<ErrorOr<Deleted>>;
