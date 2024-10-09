using MonoModularNet.Module.System.Domain.CreateConfiguration;
using MonoModularNet.Module.System.Domain.CreateEnvironmentVariable;
using MonoModularNet.Module.System.Domain.GetListConfiguration;

namespace MonoModularNet.Module.System.Controller;

[Route("api/system/environment-variables")]
public class EnvironmentVariablesController: ApiControllerBase
{
    private readonly IMediatorHandler _mediatorHandler;

    public EnvironmentVariablesController(IMediatorHandler mediatorHandler)
    {
        _mediatorHandler = mediatorHandler;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] OrderByQueryParameter queryParameter)
    {
        var result = await _mediatorHandler.SendAsync(new GetListEnvironmentVariableQuery(orderByColumn: queryParameter.OrderByColumn, orderBy: queryParameter.OrderBy));

        return new ApiOkResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEnvironmentVariableCommand command)
    {
        var result = await _mediatorHandler.SendAsync(command);

        if (!result.IsSuccess)
        {
            return new ApiBadRequestResult();
        }
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