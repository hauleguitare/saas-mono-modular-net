using MonoModularNet.Infrastructure.Shared.Common.Notification;
using MonoModularNet.Module.Auth.Domain.Model;
using MonoModularNet.Module.Auth.Shared.Interface;

namespace MonoModularNet.Module.Auth.Application.Controller;

[Route("api/auth")]
public class AuthController : ApiControllerBase
{
    private readonly ISignInService _signInService;
    private readonly ISignUpService _signUpService;
    private readonly IChangePasswordService _changePasswordService;

    public AuthController(IDomainExceptionMessageEventQueue eventQueue, ISignInService signInService, ISignUpService signUpService, IChangePasswordService changePasswordService) :
        base(eventQueue)
    {
        _signInService = signInService;
        _signUpService = signUpService;
        _changePasswordService = changePasswordService;
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInReq req)
    {
        var result = await _signInService.SignInAsync(req);
        
        ThrowIfHasError();

        return ApiOk();
    }
    
    [HttpPost("sign-out")]
    public async Task<IActionResult> SignOut()
    {
        await _signInService.SignOutAsync();
        
        ThrowIfHasError();

        return ApiOk();
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpReq req)
    {
        await _signUpService.SignUpAsync(req);
        
        ThrowIfHasError();

        return ApiOk();
    }
    

    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordReq req)
    {
        await _changePasswordService.ChangePasswordAsync(req);
        
        ThrowIfHasError();

        return ApiOk();
    }
}