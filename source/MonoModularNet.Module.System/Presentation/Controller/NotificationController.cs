using MonoModularNet.Infrastructure.Shared.Common.Notification;
using MonoModularNet.Module.System.Domain.GetNotification;

namespace MonoModularNet.Module.System.Presentation.Controller;

[Route("api/system/notifications")]
public class NotificationController: ApiControllerBase
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IMapper _mapper;
    
    
    public NotificationController(IDomainExceptionMessageEventQueue eventQueue, IMediatorHandler mediatorHandler, IMapper mapper) : base(eventQueue)
    {
        _mediatorHandler = mediatorHandler;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediatorHandler.SendAsync(new GetNotificationQuery());

        return new ApiOkResult(result);
    }
}