using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MonoModularNet.Infrastructure.Shared.Common.Attribute;
using MonoModularNet.Module.Auth.Domain.Exception;
using MonoModularNet.Module.Auth.Domain.Model;
using MonoModularNet.Module.Auth.Shared.Interface;

namespace MonoModularNet.Module.Auth.Domain.Service;

[Injectable(InterfaceType = typeof(IChangePasswordService), Lifetime = ServiceLifetime.Scoped)]
public class ChangePasswordService: IChangePasswordService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IMapper _mapper;
    private readonly ILogger<ChangePasswordService> _logger;

    public ChangePasswordService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper, ILogger<ChangePasswordService> logger, IHttpContextAccessor httpContextAccessor, IMediatorHandler mediatorHandler)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
        _mediatorHandler = mediatorHandler;
    }

    public async Task ChangePasswordAsync(ChangePasswordReq req, CancellationToken cancellationToken = default)
    {

        var isLoggedIn = await IsSignInAsync(cancellationToken);

        if (!isLoggedIn)
        {
            await _mediatorHandler.RaiseExceptionAsync(new AuthNotSignedInException(), cancellationToken);
            
            return;
        }
        
        var claimPrincipal = _httpContextAccessor.HttpContext?.User;


        var user = await _userManager.GetUserAsync(claimPrincipal!);

        var result = await _userManager.ChangePasswordAsync(user!, req.CurrentPassword, req.NewPassword);

        if (!result.Succeeded)
        {
            await _mediatorHandler.RaiseExceptionAsync(new AuthChangePasswordFailedException(result.Errors.FirstOrDefault()!.Code), cancellationToken);
        }
    }
    
    private Task<bool> IsSignInAsync(CancellationToken cancellationToken = default)
    {
        var claimPrincipal = _httpContextAccessor.HttpContext?.User;

        if (claimPrincipal is null)
        {
            return Task.FromResult(false);
        }

        return Task.FromResult(_signInManager.IsSignedIn(claimPrincipal));
    }
}