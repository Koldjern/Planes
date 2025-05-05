using MediatR;
using Microsoft.Extensions.Logging;
using PeopleDomain.EmployeeAggregate.Events;

namespace PeopleApplication.Employees.Events;

public class EmployeeDeletedHandler : INotificationHandler<EmployeeDeleted>
{
	private readonly ILogger<EmployeeDeletedHandler> _logger;

	public EmployeeDeletedHandler(ILogger<EmployeeDeletedHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(EmployeeDeleted notification, CancellationToken cancellationToken)
	{
		_logger.LogInformation($"Employee Deleted at Date: {DateTime.UtcNow}, Employee id: {notification.Deleted.Id}");
		return Task.CompletedTask;
	}
}
