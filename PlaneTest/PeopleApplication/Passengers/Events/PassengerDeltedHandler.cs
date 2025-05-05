using MediatR;
using Microsoft.Extensions.Logging;
using PeopleDomain.PassengerAggregate.Events;

namespace PeopleApplication.Passengers.Events;

public class PassengerDeltedHandler : INotificationHandler<PassengerDeleted>
{
	private readonly ILogger<PassengerDeltedHandler> _logger;

	public PassengerDeltedHandler(ILogger<PassengerDeltedHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(PassengerDeleted notification, CancellationToken cancellationToken)
	{
		_logger.LogInformation($"Passenger Deleted at Date: {DateTime.UtcNow}, Passenger id: {notification.Deleted.Id}");
		return Task.CompletedTask;
	}
}
