using MediatR;
using Microsoft.Extensions.Logging;
using TravelBlogs.Core.Application.Common.Events;
using TravelBlogs.Core.Shared.Events;

namespace TravelBlogs.Infrastructure.Common.Services;

public class EventPublisher(ILogger<EventPublisher> logger, IPublisher mediator) : IEventPublisher
{
    public Task PublishAsync(IEvent @event)
    {
        logger.LogInformation("Publishing event: {EventType}", @event.GetType().Name);
        return mediator.Publish(CreateEventNotification(@event));
    }

    private static INotification CreateEventNotification(IEvent @event)
    {
        var notificationType = typeof(EventNotification<>).MakeGenericType(@event.GetType());
        return (INotification)Activator.CreateInstance(notificationType, @event)!;
    }
}