using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.Core.Application.Common.Interfaces;

namespace TravelBlogs.Core.Application.Dto.Persistence.Catalog.Categories
{
    public class CategoryDto : IDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
