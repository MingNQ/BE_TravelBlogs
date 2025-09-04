using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelBlogs.Core.Application.Dto.Common;
using TravelBlogs.Core.Application.Dto;
using TravelBlogs.Core.Application.Common.Interfaces;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Categories;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Queries;

public class SearchCategoriesQuery : IRequest<PaginatedResult<CategoryDto>>
{
    public string? Keyword { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class SearchCategoriesQueryHandler : IRequestHandler<SearchCategoriesQuery, PaginatedResult<CategoryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper; 

    public SearchCategoriesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<CategoryDto>> Handle(SearchCategoriesQuery request, CancellationToken cancellationToken)
    {

        var query = _context.Categories.AsQueryable();


        if (!string.IsNullOrWhiteSpace(request.Keyword))
        {
            query = query.Where(c =>
                c.Name.Contains(request.Keyword));
        }


        var totalItems = await query.CountAsync(cancellationToken);
        var items = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider) 
            .ToListAsync(cancellationToken);
        return new PaginatedResult<CategoryDto>(items, totalItems, request.PageNumber, request.PageSize);
    }
}