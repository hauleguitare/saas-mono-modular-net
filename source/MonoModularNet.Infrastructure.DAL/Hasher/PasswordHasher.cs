using Microsoft.AspNetCore.Identity;
using MonoModularNet.Infrastructure.DAL.Identity;

namespace MonoModularNet.Infrastructure.DAL.Hasher;

public interface IApplicationPasswordHasher : IPasswordHasher<ApplicationUser>
{
    
}


public class ApplicationPasswordHasher: PasswordHasher<ApplicationUser>, IApplicationPasswordHasher
{
    
}