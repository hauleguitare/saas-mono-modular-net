using MonoModularNet.Infrastructure.Shared.Common.Notification;
using MonoModularNet.Module.System.Domain.CreateEnvironment;
using MonoModularNet.Module.System.Domain.DeleteEnvironment;
using MonoModularNet.Module.System.Domain.GetEnvironmentById;
using MonoModularNet.Module.System.Domain.GetListEnvironment;
using MonoModularNet.Module.System.Domain.PatchUpdateEnvironment;
using MonoModularNet.Module.System.Presentation.Model;

namespace MonoModularNet.Module.System.Presentation.Controller;

[Route("api/system/environment-variables")]
public class EnvironmentVariablesController: ApiControllerBase
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IMapper _mapper;
    
    
    public EnvironmentVariablesController(IDomainExceptionMessageEventQueue eventQueue, IMediatorHandler mediatorHandler, IMapper mapper) : base(eventQueue)
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
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediatorHandler.SendAsync(new GetEnvironmentByIdQuery(id));

        return new ApiOkResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEnvironmentReq req)
    {
        var command = _mapper.Map<CreateEnvironmentCommand>(req);
        
        var result = await _mediatorHandler.SendAsync(command);

        ThrowIfHasError();
        return new ApiOkResult();
    }

    

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] PatchUpdateEnvironmentReq req)
    {
        var command = _mapper.Map<PatchUpdateEnvironmentCommand>(req);

        command.Id = id;
        
        var result = await _mediatorHandler.SendAsync(command);
        
        ThrowIfHasError();
        return new ApiOkResult();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteEnvironmentCommand(id);

        var result = await _mediatorHandler.SendAsync(command);
        
        ThrowIfHasError();
        return new ApiOkResult();
    }
}