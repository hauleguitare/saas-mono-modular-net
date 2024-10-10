namespace MonoModularNet.Module.System.Domain.PatchUpdateEnvironment;

public class PatchUpdateEnvironmentCommand: CqrsCommand
{
    public int Id { get; set; }
    public string? Key { get; set; }
    public string? Value { get; set; }
    public PatchUpdateEnvironmentMetadataCommand? Metadata { get; set; }
}

public class PatchUpdateEnvironmentMetadataCommand
{
    public string Type { get; set; } = null!;
    public bool IsRequired { get; set; } = false;
}