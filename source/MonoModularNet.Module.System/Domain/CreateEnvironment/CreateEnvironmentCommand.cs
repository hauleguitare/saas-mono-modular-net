namespace MonoModularNet.Module.System.Domain.CreateEnvironment;

public class CreateEnvironmentCommand: CqrsCommand
{
    public string Key { get; set; } = null!;
    public string? Value { get; set; }

    public CreateEnvironmentMetadataCommand Metadata { get; set; } = new CreateEnvironmentMetadataCommand();
}

public class CreateEnvironmentMetadataCommand
{
    public string Type { get; set; } = null!;
    public bool IsRequired { get; set; } = false;
}