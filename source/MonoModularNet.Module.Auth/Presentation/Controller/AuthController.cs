using MonoModularNet.Infrastructure.Shared.Common.Notification;
using MonoModularNet.Module.Auth.Domain.Model;
using MonoModularNet.Module.Auth.Domain.SignUp.Command;
using MonoModularNet.Module.Auth.Presentation.Model;

namespace MonoModularNet.Module.Auth.Presentation.Controller;

[Route("api/auth")]
public class AuthController : ApiControllerBase
{
    private readonly IMediatorHandler _mediatorHandler;

    public AuthController(IDomainExceptionMessageEventQueue eventQueue, IMediatorHandler mediatorHandler) :
        base(eventQueue)
    {
        _mediatorHandler = mediatorHandler;
    }

    [HttpPost("sign-in")]
    public Task<IActionResult> SignIn([FromBody] SignInReq req)
    {
        throw new NotImplementedException();
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpReq req)
    {
        var command = new SignUpCommand(req.Email, req.Password);
        await _mediatorHandler.SendAsync(command);

        ThrowIfCommandHasError();

        return new ApiOkResult("Ok");
    }

    [HttpPost("email-confirmation")]
    public Task<IActionResult> EmailConfirmation()
    {
        throw new NotImplementedException();
    }

    [HttpPost("change-password")]
    public Task<IActionResult> ChangePassword()
    {
        throw new NotImplementedException();
    }
}