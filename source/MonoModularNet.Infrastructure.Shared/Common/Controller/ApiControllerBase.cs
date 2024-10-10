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
    protected StringValues GetContentLanguage() => HttpContext.Request.Headers.ContentLanguage;
    
    [NonAction]
    protected void ThrowIfCommandHasError()
    {
        if (_eventQueue.HasException())
        {
            var queue = _eventQueue.Dequeue();

            throw new Exception("Exception from queue");
        }
    }
}