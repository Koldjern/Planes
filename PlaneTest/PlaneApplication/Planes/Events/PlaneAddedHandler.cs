using MediatR;
using Microsoft.Extensions.Logging;
using PlaneDomain.PlaneAggregate.Events;

namespace PlaneApplication.Planes.Events;

public class PlaneAddedHandler : INotificationHandler<PlaneAdded>
{
	private readonly ILogger<PlaneAddedHandler> _logger;

	public PlaneAddedHandler(ILogger<PlaneAddedHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(PlaneAdded notification, CancellationToken cancellationToken)
	{
		_logger.LogInformation($"Plane created at Date: {DateTime.UtcNow}, \nPlane id: {notification.Plane.Id} {notification.Plane}");
		return Task.CompletedTask;
	}
}
