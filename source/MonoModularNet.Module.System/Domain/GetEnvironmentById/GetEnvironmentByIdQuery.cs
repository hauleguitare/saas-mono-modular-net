using MonoModularNet.Module.System.Domain.Model;

namespace MonoModularNet.Module.System.Domain.GetEnvironmentById;

public class GetEnvironmentByIdQuery: CqrsQuery<EnvironmentRes?>
{
    public GetEnvironmentByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; } 
}

