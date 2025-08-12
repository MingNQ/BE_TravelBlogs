using Ardalis.Specification;

namespace TravelBlogs.Core.Application.Common.Persistences;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
{
    // This interface can be extended with additional methods specific to read operations if needed.
}