using MediatR;
using Microsoft.Extensions.Logging;
using TravelDomain.TravelAggregate.Events;

namespace TravelApplication.Travels.Events;

public class TravelEndedHandler : INotificationHandler<TravelEnded>
{
	private readonly ILogger<TravelEndedHandler> _logger;
	private readonly ITravelRepository _repository;

	public TravelEndedHandler(ILogger<TravelEndedHandler> logger, ITravelRepository repository)
	{
		_logger = logger;
		_repository = repository;
	}

	public Task Handle(TravelEnded notification, CancellationToken cancellationToken)
	{
		Task.Run(() => Act(notification, cancellationToken));
		return Task.CompletedTask;
	}
	private async Task Act(TravelEnded notification, CancellationToken cancellationToken)
	{
		var sleepFor = notification.Travel.TimeLeft();
		await Task.Delay(sleepFor);
		var deleted = await _repository.Delete(notification.Travel.Id);

		if (deleted)
			_logger.LogInformation($"Travel id: {notification.Travel.Id} ended at {notification.Travel.FlightEnds}");
		else
			_logger.LogError($"Travel id: {notification.Travel.Id} didnt End at {notification.Travel.FlightEnds}");
	}
}
