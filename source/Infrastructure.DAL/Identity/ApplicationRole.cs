using Microsoft.AspNetCore.Identity;

namespace Infrastructure.DAL.Identity;

public sealed class ApplicationRole: IdentityRole
{
    public ICollection<ApplicationRoleClaim> AspNetRoleClaims { get; set; } = new List<ApplicationRoleClaim>();

    public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
}
