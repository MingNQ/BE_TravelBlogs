using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelBlogs.Core.Application.Common.Interfaces;
using TravelBlogs.Core.Application.Dto;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Categories;
using AutoMapper;
namespace TravelBlogs.Core.Application.Cqrs.Categories.Queries;

public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public long Id { get; set; }
}

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories
            .AsNoTracking() // Dùng AsNoTracking để tăng hiệu suất vì đây là lệnh chỉ đọc
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        // Cần thêm xử lý nếu không tìm thấy category, ví dụ: throw new NotFoundException();

        return _mapper.Map<CategoryDto>(category);
    }
}