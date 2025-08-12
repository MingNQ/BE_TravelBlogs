using Ardalis.Specification;
using TravelBlogs.Core.Application.Common.Interfaces;
using TravelBlogs.Core.Application.Common.Models;
using TravelBlogs.Core.Application.Common.Services;

namespace TravelBlogs.Infrastructure.Services;

public class PaginationService : IPaginationService
{
    public async Task<PaginationResponse<TDestination>> PaginatedListAsync<T, TDestination>(
        IReadRepositoryBase<T> repository,
        ISpecification<T, TDestination> spec,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
        where T : class
        where TDestination : class, IDto
    {
        return await repository.PaginatedListAsync(spec, pageNumber, pageSize, cancellationToken);
    }

    public async Task<PaginationResponse<TDestination>> PaginatedListAsync<T, TDestination>(
        IReadRepositoryBase<T> repository,
        ISpecification<T, TDestination> spec,
        int pageNumber,
        int pageSize,
        bool ignorePagination,
        CancellationToken cancellationToken = default)
        where T : class
        where TDestination : class, IDto
    {
        return await repository.PaginatedListAsync(spec, pageNumber, ignorePagination ? 99999 : pageSize, cancellationToken);
    }

    public async Task<PaginationResponse<T>> PaginatedListAsync<T>(
        IReadRepositoryBase<T> repository,
        ISpecification<T> spec,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
        where T : class
    {
        return await repository.PaginatedListAsync(spec, pageNumber, pageSize, cancellationToken);
    }
}