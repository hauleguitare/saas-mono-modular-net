using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Infrastructure.Shared.Common.Controller;

[ApiController]
public abstract class ApiControllerBase: ControllerBase
{
    [NonAction]
    protected StringValues GetContentLanguage() => HttpContext.Request.Headers.ContentLanguage;
}