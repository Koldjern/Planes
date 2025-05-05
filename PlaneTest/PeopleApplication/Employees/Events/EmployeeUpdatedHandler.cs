using MediatR;
using Microsoft.Extensions.Logging;
using PeopleDomain.EmployeeAggregate.Events;

namespace PeopleApplication.Employees.Events;

public class EmployeeUpdatedHandler : INotificationHandler<EmployeeUpdated>
{
	private readonly ILogger<EmployeeUpdatedHandler> _logger;

	public EmployeeUpdatedHandler(ILogger<EmployeeUpdatedHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(EmployeeUpdated notification, CancellationToken cancellationToken)
	{
		_logger.LogInformation($"Employee updated at Date: {DateTime.UtcNow}, Employee id: {notification.After.Id}, \nEmployee Before: ({notification.Before})\nEmployee After: ({notification.After})");
		return Task.CompletedTask;
	}
}
