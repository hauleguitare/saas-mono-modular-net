using Microsoft.AspNetCore.Identity;

namespace Infrastructure.DAL.Identity;

public sealed class ApplicationRoleClaim: IdentityRoleClaim<string>
{
    public ApplicationRole Role { get; set; } = null!;
}
