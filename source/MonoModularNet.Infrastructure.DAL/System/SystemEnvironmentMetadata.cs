using Core.Common.Entity;

namespace MonoModularNet.Infrastructure.DAL.System;

public class SystemEnvironmentMetadata: ValueObject
{
    public string Type { get; set; } = null!;
    
    public bool IsRequired { get; set; } = false;
    public virtual SystemEnvironment? Environment { get; set; }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Type;
        yield return IsRequired;
    }
}