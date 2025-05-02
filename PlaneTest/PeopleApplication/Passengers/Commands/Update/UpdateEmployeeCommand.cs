using ErrorOr;
using MediatR;

namespace PeopleApplication.Passengers.Commands.Update;

public record UpdatePassengerCommand(Guid Id, double Weight)
	: IRequest<ErrorOr<Updated>>;