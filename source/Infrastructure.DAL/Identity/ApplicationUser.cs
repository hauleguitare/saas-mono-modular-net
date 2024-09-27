using Microsoft.AspNetCore.Identity;

namespace Infrastructure.DAL.Identity;

public sealed class ApplicationUser: IdentityUser
{
    public ICollection<ApplicationUserClaim> UserClaims { get; set; } = new List<ApplicationUserClaim>();

    public ICollection<ApplicationUserLogin> UserLogins { get; set; } = new List<ApplicationUserLogin>();

    public ICollection<ApplicationUserToken> UserTokens { get; set; } = new List<ApplicationUserToken>();

    public ICollection<ApplicationRole> Roles { get; set; } = new List<ApplicationRole>();
}
