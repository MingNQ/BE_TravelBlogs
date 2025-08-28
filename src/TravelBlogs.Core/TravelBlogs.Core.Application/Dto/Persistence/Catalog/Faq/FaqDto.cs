using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.Core.Application.Common.Interfaces;

namespace TravelBlogs.Core.Application.Dto.Persistence.Catalog.Faq
{
    public class FaqDto : IDto
    {
        public long Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}
