using Core.Common.Entity;

namespace Core.Entity.System;

public class SystemEnvironment: BaseEntity<int>, IAggregateRoot
{
    public string Key { get; set; } = null!;
    public string? Value { get; set; }
    
    public virtual SystemEnvironmentMetadata? Metadata { get; set; }
}