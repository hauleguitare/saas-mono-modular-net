using Microsoft.AspNetCore.Mvc;
using MonoModularNet.Infrastructure.CQRS.Mediator;
using MonoModularNet.Infrastructure.Shared.Common.Controller;
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
        return Task.FromResult<IActionResult>(new ApiOkResult("Ok"));
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpReq req)
    {
        var command = new SignUpCqrsCommand(email: req.Email, password: req.Password);
        await _mediatorHandler.SendAsync(command);

        return new ApiOkResult("Ok");
    }
}