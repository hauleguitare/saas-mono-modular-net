namespace MonoModularNet.Module.System.Presentation.Model;

public class CreateEnvironmentVariableReq
{
    public string Key { get; set; } = null!;
    public string? Value { get; set; }

    public CreateEnvironmentVariableMetadataReq Metadata { get; set; } = new CreateEnvironmentVariableMetadataReq();
}

public class CreateEnvironmentVariableMetadataReq
{
    public string Type { get; set; } = null!;
    public bool IsRequired { get; set; } = false;
}