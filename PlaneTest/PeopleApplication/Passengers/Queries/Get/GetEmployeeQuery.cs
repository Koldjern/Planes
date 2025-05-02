using ErrorOr;
using MediatR;
using PeopleDomain.PassengerAggregate;

namespace PeopleApplication.Passengers.Queries.Get;

public record GetPassengerQuery(Guid Id)
	: IRequest<ErrorOr<Passenger>>;