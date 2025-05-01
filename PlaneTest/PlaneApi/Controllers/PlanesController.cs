using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlaneApi.Contracts;
using PlaneApplication.Planes.Commands.Add;
using PlaneApplication.Planes.Commands.Delete;
using PlaneApplication.Planes.Commands.Update;
using PlaneApplication.Planes.Queries.Get;
using PlaneApplication.Planes.Queries.GetAll;
using SubApi.Controllers;

namespace PlaneApi.Controllers;

[Route("planes")]
public class PlanesController : ApiController
{
	private readonly ISender _mediator;
	private readonly IMapper _mapper;

	public PlanesController(ISender mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetPlane(Guid id)
	{
		var query = new GetPlaneQuery(id);
		var result = await _mediator.Send(query);

		return result.Match(
			result => Ok(_mapper.Map<PlaneResponse>(result)),
			Problem);
	}

	[HttpGet]
	public async Task<IActionResult> GetPlanes()
	{
		var query = new GetAllPlanesQuery();
		var result = await _mediator.Send(query);

		return result.Match(
			result => Ok(_mapper.Map<PlanesResponse>(result)),
			Problem);
	}

	[HttpPost]
	public async Task<IActionResult> AddPlane(AddPlaneRequest request)
	{
		var command = _mapper.Map<AddPlaneCommand>(request);

		var result = await _mediator.Send(command);

		return result.Match(
			id => Created("planes/" + id, id),
			Problem);
	}

	[HttpPut]
	public async Task<IActionResult> UpdatePlane(UpdatePlaneRequest request)
	{
		if (request.Id == Guid.Empty || request.Id is null)
			return BadRequest("No Id");

		return await Update(_mapper.Map<UpdatePlaneCommand>(request));
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdatePlane(Guid id, [FromBody] UpdatePlaneRequest request)
	{
		if (request.Id is null)
			return BadRequest("No Id");

		return await Update(new UpdatePlaneCommand(
			id,
			request.MotorId,
			request.MotorName,
			request.Power,
			request.Consumption,
			request.Type,
			request.WeightKg,
			request.MaxWeight,
			request.Name,
			request.MaxSpeed));
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeletePlane(Guid id)
	{
		var command = new DeletePlaneCommand(id);

		var result = await _mediator.Send(command);

		return result.Match(
			deleted => Ok(),
			Problem);
	}
	public async Task<IActionResult> Update(UpdatePlaneCommand command)
	{
		var result = await _mediator.Send(command);

		return result.Match(
			updated => Ok(),
			Problem);
	}
}
