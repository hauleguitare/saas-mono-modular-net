using Microsoft.AspNetCore.Identity;

namespace MonoModularNet.Infrastructure.DAL.Identity;

public class ApplicationRole: IdentityRole
{
    public int Priority { get; set; }
}
