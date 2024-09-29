using Microsoft.AspNetCore.Identity;

namespace MonoModularNet.Infrastructure.DAL.Identity;

public sealed class ApplicationUserClaim: IdentityUserClaim<string>
{
    public ApplicationUser User { get; set; } = null!;
}
