using MediatR;
using Microsoft.Extensions.Logging;
using PlaneDomain.PlaneAggregate.Events;

namespace PlaneApplication.Planes.Events;

public class PlaneUpdateHandler : INotificationHandler<PlaneUpdated>
{
	private readonly ILogger<PlaneUpdateHandler> _logger;

	public PlaneUpdateHandler(ILogger<PlaneUpdateHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(PlaneUpdated notification, CancellationToken cancellationToken)
	{
		_logger.LogInformation($"Plane updated at Date: {DateTime.UtcNow}, Plane id: {notification.After.Id}, \nPlane Before: ({notification.Before})\nPlane After: ({notification.After})");
		return Task.CompletedTask;
	}
}
