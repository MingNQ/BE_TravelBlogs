using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.Core.Application.Common.Interfaces;

namespace TravelBlogs.Core.Application.Dto.Persistence.Catalog.Contact
{
    public class ContactDto : IDto
    {
        public long Id { get; set; }
        public string Subject {  get; set; } = String.Empty;
        public string Content {  get; set; } = String.Empty;

        public long UserId { get; set; }
    }
}
