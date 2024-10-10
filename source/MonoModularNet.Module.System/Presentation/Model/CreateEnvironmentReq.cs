namespace MonoModularNet.Module.System.Presentation.Model;

public record CreateEnvironmentReq
{
    public string Key { get; set; } = null!;
    public string? Value { get; set; }

    public CreateEnvironmentMetadataReq Metadata { get; set; } = new CreateEnvironmentMetadataReq();
}

public record CreateEnvironmentMetadataReq
{
    public string Type { get; set; } = null!;
    public bool IsRequired { get; set; } = false;
}