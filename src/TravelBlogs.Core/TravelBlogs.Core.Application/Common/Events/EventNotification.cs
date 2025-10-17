using MediatR;
using TravelBlogs.Core.Shared.Events;

namespace TravelBlogs.Core.Application.Common.Events;

public class EventNotification<TEvent>(TEvent @event) : INotification
    where TEvent : IEvent
{
    public TEvent Event { get; } = @event;
}