using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SubApi.Controllers;
using TravelApi.Contracts;
using TravelApplication.Travels.Commands.StartFlight;
using TravelApplication.Travels.Queries.CheckTravel;
using TravelApplication.Travels.Responses;

namespace TravelApi.Controllers;
[Route("travels")]
public class TravelController : ApiController
{
	private readonly ISender _mediator;
	private readonly IMapper _mapper;

	public TravelController(ISender mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> CheckTravel([FromRoute] Guid id, [FromQuery] string? kmOrMiles)
	{
		var query = new CheckTravelQuery(id, kmOrMiles);
		var result = await _mediator.Send(query);

		return result.Match(
			response => Ok(_mapper.Map<TravelResponse>(response)),
			Problem);
	}

	[HttpPost]
	public async Task<IActionResult> StartFlight(StartFlightRequest request)
	{
		var command = _mapper.Map<StartFlightCommand>(request);

		var result = await _mediator.Send(command);

		return result.Match(
			response => Created("planes/" + response.Id, response),
			Problem);
	}
}
