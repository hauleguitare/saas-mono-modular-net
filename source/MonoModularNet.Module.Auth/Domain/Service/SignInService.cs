using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MonoModularNet.Infrastructure.Shared.Common.Attribute;
using MonoModularNet.Module.Auth.Domain.Exception;
using MonoModularNet.Module.Auth.Domain.Model;
using MonoModularNet.Module.Auth.Shared.Interface;

namespace MonoModularNet.Module.Auth.Domain.Service;

[Injectable(InterfaceType = typeof(ISignInService), Lifetime = ServiceLifetime.Scoped)]
public class SignInService: ISignInService
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;
    private readonly IMediatorHandler _mediatorHandler;

    public SignInService(SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IMapper mapper, IMediatorHandler mediatorHandler)
    {
        _signInManager = signInManager;
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
        _mapper = mapper;
        _mediatorHandler = mediatorHandler;
    }

    public async Task<SignInRes> SignInAsync(SignInReq req, CancellationToken cancellationToken = default)
    {
        var isSignIn = await IsSignInAsync(cancellationToken);
        
        if (isSignIn)
        {
            await _mediatorHandler.RaiseExceptionAsync(new AuthSignedInAlreadyException(), cancellationToken);
        }

        var result = await _signInManager.PasswordSignInAsync(req.Email, req.Password, true, true);

        if (!result.Succeeded)
        {
            await _mediatorHandler.RaiseExceptionAsync(new AuthSignedInAlreadyException(), cancellationToken);
        }

        var claimPrincipal = _httpContextAccessor.HttpContext?.User;
        var user = await _userManager.GetUserAsync(claimPrincipal!);
        var signInRes = _mapper.Map<SignInRes>(user);

        return signInRes;
    }

    public async Task SignOutAsync(CancellationToken cancellationToken = default)
    {
        var isSignIn = await IsSignInAsync(cancellationToken);

        if (!isSignIn)
        {
            await _mediatorHandler.RaiseExceptionAsync(new AuthNotSignedInException(), cancellationToken);
        }
        
        await _signInManager.SignOutAsync();
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