namespace Application.Dto.Persistence.Catalog.UserRole;

public class UserRolesDtoInput
{
    public long UserId { get; set; }
    public List<long> RoleIds { get; set; } = [];
}