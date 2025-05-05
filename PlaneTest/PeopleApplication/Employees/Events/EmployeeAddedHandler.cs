using MediatR;
using Microsoft.Extensions.Logging;
using PeopleDomain.EmployeeAggregate.Events;

namespace PeopleApplication.Employees.Events;

public class EmployeeAddedHandler : INotificationHandler<EmployeeAdded>
{
	private readonly ILogger<EmployeeAddedHandler> _logger;

	public EmployeeAddedHandler(ILogger<EmployeeAddedHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(EmployeeAdded notification, CancellationToken cancellationToken)
	{
		_logger.LogInformation($"Employee created at Date: {DateTime.UtcNow}, \nEmployee id: {notification.Employee.Id} {notification.Employee}");
		return Task.CompletedTask;
	}
}
