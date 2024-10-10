namespace MonoModularNet.Module.System.Domain.DeleteEnvironment;

public class DeleteEnvironmentCommand : CqrsCommand
{
    public DeleteEnvironmentCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}