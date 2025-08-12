using System.ComponentModel.DataAnnotations.Schema;
using TravelBlogs.Core.Domain.Common.Contracts;

namespace TravelBlogs.Core.Domain.Entities.Identity;

public class UserRole : AuditableEntity<long>
{
    public long UserId { get; set; }

    public long RoleId { get; set; }

    public virtual User? User { get; set; }
    public virtual Role? Role { get; set; }
}