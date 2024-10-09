namespace MonoModularNet.Module.System.Domain.CreateEnvironmentVariable;

public class CreateEnvironmentVariableCommand: CqrsCommand
{
    public string Key { get; set; } = null!;
    public string? Value { get; set; }

    public CreateEnvironmentVariableMetadataCommand Metadata { get; set; } = new CreateEnvironmentVariableMetadataCommand();
}

public class CreateEnvironmentVariableMetadataCommand
{
    public string Type { get; set; } = null!;
    public bool IsRequired { get; set; } = false;
}