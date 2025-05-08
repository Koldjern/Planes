using ErrorOr;
using MediatR;
using TravelApplication.Travels.Responses;
using TravelDomain.TravelAggregate.Errors;

namespace TravelApplication.Travels.Queries.CheckTravel;

public class CheckTravelQueryHandler : IRequestHandler<CheckTravelQuery, ErrorOr<TravelResponse>>
{
	private readonly ITravelRepository _repository;

	public CheckTravelQueryHandler(ITravelRepository repository)
	{
		_repository = repository;
	}

	public async Task<ErrorOr<TravelResponse>> Handle(CheckTravelQuery request, CancellationToken cancellationToken)
	{
		var travel = await _repository.Get(request.Id);

		if (travel is null)
			return Errors.Travel.TravelNotFound;

		return new TravelResponse(
			travel.Id,
			travel.TotalWages(),
			travel.TotalTickets(),
			travel.FuelConsumption(),
			travel.TimeLeft(),
			DistanceResponse.KmOrMiles(request.KmOrMiles, travel),
			travel.FlightEnds);
	}
}
