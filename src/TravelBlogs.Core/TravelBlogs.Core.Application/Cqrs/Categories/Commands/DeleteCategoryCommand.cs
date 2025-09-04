using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TravelBlogs.Core.Application.Common.Interfaces;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Commands;

public class DeleteCategoryCommand : IRequest
{
    public long Id { get; set; }
}

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FindAsync(request.Id);


        if (category != null)
        {
            _context.Categories.Remove(category); // BaseDbContext sẽ tự xử lý Soft Delete
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}