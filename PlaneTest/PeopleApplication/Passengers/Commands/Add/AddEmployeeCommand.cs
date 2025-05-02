using ErrorOr;
using MediatR;

namespace PeopleApplication.Passengers.Commands.Add;

public record AddPassengerCommand(
	double Weight)
	: IRequest<ErrorOr<Guid>>;