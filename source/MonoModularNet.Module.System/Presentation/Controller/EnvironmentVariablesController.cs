using MonoModularNet.Infrastructure.Shared.Common.Notification;
using MonoModularNet.Module.System.Domain.CreateEnvironmentVariable;
using MonoModularNet.Module.System.Domain.GetListConfiguration;
using MonoModularNet.Module.System.Presentation.Model;

namespace MonoModularNet.Module.System.Presentation.Controller;

[Route("api/system/environment-variables")]
public class EnvironmentVariablesController: ApiControllerBase
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IMapper _mapper;
    
    
    public EnvironmentVariablesController(IExceptionDomainEventQueue eventQueue, IMediatorHandler mediatorHandler, IMapper mapper) : base(eventQueue)
    {
        _mediatorHandler = mediatorHandler;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] OrderByQueryParameter queryParameter)
    {
        var result = await _mediatorHandler.SendAsync(new GetListEnvironmentVariableQuery(orderByColumn: queryParameter.OrderByColumn, orderBy: queryParameter.OrderBy));

        return new ApiOkResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEnvironmentVariableReq req)
    {
        var command = _mapper.Map<CreateEnvironmentVariableCommand>(req);
        
        var result = await _mediatorHandler.SendAsync(command);

        ThrowIfCommandHasError();
        return new ApiOkResult();
    }

    

    [HttpPatch]
    public Task<IActionResult> Patch()
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public Task<IActionResult> Delete()
    {
        throw new NotImplementedException();
    }
}