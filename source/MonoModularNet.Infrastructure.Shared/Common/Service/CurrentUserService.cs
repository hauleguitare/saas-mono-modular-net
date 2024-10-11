using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MonoModularNet.Infrastructure.Shared.Common.Attribute;

namespace MonoModularNet.Infrastructure.Shared.Common.Service;



public interface ICurrentUserService
{
    public string? UserId { get; }
    
    public bool IsLoggedIn { get; }
}

[Injectable(InterfaceType = typeof(ICurrentUserService), Lifetime = ServiceLifetime.Scoped)]
public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string UserId => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

    public bool IsLoggedIn => _httpContextAccessor.HttpContext?.User != null;
}