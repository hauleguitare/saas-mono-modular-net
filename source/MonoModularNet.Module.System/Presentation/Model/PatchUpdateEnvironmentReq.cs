namespace MonoModularNet.Module.System.Presentation.Model;

public record PatchUpdateEnvironmentReq
{
    public string? Key { get; set; }
    public string? Value { get; set; }
    public PatchUpdateEnvironmentMetadataReq? Metadata { get; set; }
}

public record PatchUpdateEnvironmentMetadataReq
{
    public string Type { get; set; } = null!;
    public bool IsRequired { get; set; } = false;
}