namespace MonoModularNet.Module.System.Domain.Model;

public class ConfigurationRes
{
    public int Id { get; set; }
    public string Key { get; set; } = null!;
    public string Type { get; set; } = null!;
    public object? Value { get; set; }
}