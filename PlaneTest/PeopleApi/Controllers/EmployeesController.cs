using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PeopleApi.Contracts.Employee;
using PeopleApplication.Employees.Commands.Add;
using PeopleApplication.Employees.Commands.Delete;
using PeopleApplication.Employees.Commands.Update;
using PeopleApplication.Employees.Queries.Get;
using PeopleApplication.Employees.Queries.GetAll;
using SubApi.Controllers;

namespace PeopleApi.Controllers;
[Route("employees")]
public class EmployeesController : ApiController
{
	private readonly ISender _mediator;
	private readonly IMapper _mapper;

	public EmployeesController(ISender mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetEmployee(Guid id)
	{
		var query = new GetEmployeeQuery(id);
		var result = await _mediator.Send(query);

		return result.Match(
			result => Ok(_mapper.Map<EmployeeResponse>(result)),
			Problem);
	}

	[HttpGet]
	public async Task<IActionResult> GetEmployee()
	{
		var query = new GetAllEmployeesQuery();
		var result = await _mediator.Send(query);

		return result.Match(
			result => Ok(_mapper.Map<EmployeesResponse>(result)),
			Problem);
	}

	[HttpPost]
	public async Task<IActionResult> AddEmployee(AddEmployeeRequest request)
	{
		var command = _mapper.Map<AddEmployeeCommand>(request);

		var result = await _mediator.Send(command);

		return result.Match(
			id => Created("employee/" + id, id),
			Problem);
	}

	[HttpPut]
	public async Task<IActionResult> UpdateEmployee(UpdateEmployeeRequest request)
	{
		return await Update(_mapper.Map<UpdateEmployeeCommand>(request));
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] UpdateEmployeeRequest request)
	{
		return await Update(new UpdateEmployeeCommand(
			id,
			request.HourWage,
			request.Weight,
			request.JobTitle));
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteEmployee(Guid id)
	{
		var command = new DeleteEmployeeCommand(id);

		var result = await _mediator.Send(command);

		return result.Match(
			deleted => Ok(),
			Problem);
	}
	public async Task<IActionResult> Update(UpdateEmployeeCommand command)
	{
		var result = await _mediator.Send(command);

		return result.Match(
			updated => Ok(),
			Problem);
	}
}
