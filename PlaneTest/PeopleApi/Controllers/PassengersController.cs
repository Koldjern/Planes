using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PeopleApi.Contracts.Passenger;
using PeopleApplication.Passengers.Commands.Add;
using PeopleApplication.Passengers.Commands.Delete;
using PeopleApplication.Passengers.Commands.Update;
using PeopleApplication.Passengers.Queries.Get;
using PeopleApplication.Passengers.Queries.GetAll;
using SubApi.Controllers;

namespace PeopleApi.Controllers;

[Route("passengers")]
public class PassengersController : ApiController
{
	private readonly ISender _mediator;
	private readonly IMapper _mapper;

	public PassengersController(ISender mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetPassenger(Guid id)
	{
		var query = new GetPassengerQuery(id);
		var result = await _mediator.Send(query);

		return result.Match(
			result => Ok(_mapper.Map<PassengerResponse>(result)),
			Problem);
	}

	[HttpGet]
	public async Task<IActionResult> GetPassenger()
	{
		var query = new GetAllPassengersQuery();
		var result = await _mediator.Send(query);

		return result.Match(
			result => Ok(_mapper.Map<PassengersResponse>(result)),
			Problem);
	}

	[HttpPost]
	public async Task<IActionResult> AddPassenger(AddPassengerRequest request)
	{
		var command = _mapper.Map<AddPassengerCommand>(request);

		var result = await _mediator.Send(command);

		return result.Match(
			id => Created("Passenger/" + id, id),
			Problem);
	}

	[HttpPut]
	public async Task<IActionResult> UpdatePassenger(UpdatePassengerRequest request)
	{
		return await Update(_mapper.Map<UpdatePassengerCommand>(request));
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdatePassenger(Guid id, [FromBody] UpdatePassengerRequest request)
	{
		return await Update(new UpdatePassengerCommand(
			id,
			request.Weight));
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeletePassenger(Guid id)
	{
		var command = new DeletePassengerCommand(id);

		var result = await _mediator.Send(command);

		return result.Match(
			deleted => Ok(),
			Problem);
	}
	public async Task<IActionResult> Update(UpdatePassengerCommand command)
	{
		var result = await _mediator.Send(command);

		return result.Match(
			updated => Ok(),
			Problem);
	}
}
