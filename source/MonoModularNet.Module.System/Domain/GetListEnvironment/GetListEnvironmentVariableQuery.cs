using MonoModularNet.Module.System.Domain.Model;

namespace MonoModularNet.Module.System.Domain.GetListConfiguration;

public class GetListEnvironmentVariableQuery: CqrsQuery<IReadOnlyList<ConfigurationRes>>
{
    public GetListEnvironmentVariableQuery(string? orderBy, string? orderByColumn)
    {
        OrderBy = orderBy;
        OrderByColumn = orderByColumn;
    }

    // just only DESC OR ESC
    public string? OrderBy { get; set; } = "esc";
    
    public string? OrderByColumn { get; set; }
}