using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using MonoModularNet.Infrastructure.Shared.Common.Notification;

namespace MonoModularNet.Infrastructure.Shared.Common.Controller;

[ApiController]
public abstract class ApiControllerBase: ControllerBase
{
    private readonly IDomainExceptionMessageEventQueue _eventQueue;

    protected ApiControllerBase(IDomainExceptionMessageEventQueue eventQueue)
    {
        _eventQueue = eventQueue;
    }


    [NonAction]
    protected ApiOkResult ApiOk(Object? obj = null)
    {
        return new ApiOkResult(obj);
    }

    [NonAction]
    protected StringValues GetContentLanguage() => HttpContext.Request.Headers.ContentLanguage;
    
    [NonAction]
    protected void ThrowIfHasError()
    {
        if (_eventQueue.HasException())
        {
            var domainException = _eventQueue.Dequeue();

            throw domainException;
        }
    }
}