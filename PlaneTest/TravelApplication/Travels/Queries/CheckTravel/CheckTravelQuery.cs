using ErrorOr;
using MediatR;
using TravelApplication.Travels.Responses;

namespace TravelApplication.Travels.Queries.CheckTravel;

public record CheckTravelQuery(Guid Id)
	: IRequest<ErrorOr<TravelResponse>>;
