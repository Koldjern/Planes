using MediatR;
using Microsoft.Extensions.Logging;
using PlaneDomain.PlaneAggregate.Events;

namespace PlaneApplication.Planes.Events;

public class PlaneDeletedHandler : INotificationHandler<PlaneDeleted>
{
	private readonly ILogger<PlaneDeletedHandler> _logger;

	public PlaneDeletedHandler(ILogger<PlaneDeletedHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(PlaneDeleted notification, CancellationToken cancellationToken)
	{
		_logger.LogInformation($"Plane Deleted at Date: {DateTime.UtcNow}, Plane id: {notification.Deleted.Id}");
		return Task.CompletedTask;
	}
}
