using TravelBlogs.Core.Application.Common.Interfaces;
using TravelBlogs.Core.Shared.Events;

namespace TravelBlogs.Core.Application.Common.Events;

public interface IEventPublisher : ITransientService
{
    Task PublishAsync(IEvent @event);
}