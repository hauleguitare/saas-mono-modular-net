using Microsoft.AspNetCore.Mvc;
using MonoModularNet.Infrastructure.Shared.Common.Controller;
using MonoModularNet.Module.Auth.Model;

namespace MonoModularNet.Module.Auth.Controller;

[Route("api/auth")]
public class AuthController: ApiControllerBase
{
    [HttpPost]
    public Task<IActionResult> SignIn([FromBody] SignInReq req)
    {
        return Task.FromResult<IActionResult>(new ApiOkResult("Ok"));
    }
}