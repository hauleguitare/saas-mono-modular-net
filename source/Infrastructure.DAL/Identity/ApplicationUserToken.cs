using Microsoft.AspNetCore.Identity;

namespace Infrastructure.DAL.Identity;

public sealed class ApplicationUserToken: IdentityUserToken<string>
{
    public string UserId { get; set; } = null!;

    public string LoginProvider { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Value { get; set; }

    public ApplicationUser User { get; set; } = null!;
}
