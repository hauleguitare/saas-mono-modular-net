using Core.Common.Entity;
using Core.Entity;

namespace MonoModularNet.Infrastructure.DAL.System;

public class SystemEnvironment: BaseEntity<int>, IAggregateRoot
{
    public SystemEnvironment()
    {
        Metadata = new SystemEnvironmentMetadata();
    }

    public string Key { get; set; } = null!;
    public string? Value { get; set; }
    
    public SystemEnvironmentMetadata Metadata { get; set; }
}