using MonoModularNet.Module.Auth.Domain.Handler;
using MonoModularNet.Module.Auth.Domain.Model;

namespace MonoModularNet.Module.Auth.Controller;

[Route("api/auth")]
public class AuthController: ApiControllerBase
{
    private readonly IMediatorHandler _mediatorHandler;

    public AuthController(IMediatorHandler mediatorHandler)
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
        var command = new SignUpCqrsCommand(email: req.Email, password: req.Password);
        await _mediatorHandler.SendAsync(command);

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