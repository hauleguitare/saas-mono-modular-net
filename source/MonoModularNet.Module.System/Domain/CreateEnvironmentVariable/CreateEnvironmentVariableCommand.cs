namespace MonoModularNet.Module.System.Domain.CreateEnvironmentVariable;

public class CreateEnvironmentVariableCommand: CqrsCommand
{
    public string Key { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string? Value { get; set; }
}