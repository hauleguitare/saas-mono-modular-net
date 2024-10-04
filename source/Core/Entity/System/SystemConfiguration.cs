using Core.Common.Entity;

namespace Core.Entity.System;

public class SystemConfiguration: BaseEntity<int>, IAggregateRoot
{
    public string Key { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string? Value { get; set; }
}