namespace MonoModularNet.Module.System.Domain.CreateConfiguration;

public class CreateConfigurationCommand: CqrsCommand
{
    public string Key { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string? Value { get; set; }
}