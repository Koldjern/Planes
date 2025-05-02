using ErrorOr;
using MediatR;
using PeopleDomain.PassengerAggregate;

namespace PeopleApplication.Passengers.Queries.GetAll;

public record GetAllPassengersQuery()
	: IRequest<ErrorOr<IEnumerable<Passenger>>>;