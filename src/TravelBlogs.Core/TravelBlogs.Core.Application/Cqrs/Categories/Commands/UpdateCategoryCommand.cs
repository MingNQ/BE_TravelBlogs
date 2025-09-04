using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TravelBlogs.Core.Application.Common.Interfaces;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Commands;

public class UpdateCategoryCommand : IRequest
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FindAsync(request.Id);


        if (category != null)
        {
            category.Name = request.Name;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}