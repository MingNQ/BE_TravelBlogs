using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.Core.Domain.Common.Contracts;

namespace TravelBlogs.Core.Domain.Entities
{
    public class Category : AuditableEntity<long>
    {
        public string Name { get; set; } = string.Empty;
    }
}
