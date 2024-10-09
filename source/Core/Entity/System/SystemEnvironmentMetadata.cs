namespace Core.Entity.System;

public class SystemEnvironmentMetadata: BaseEntity<int>
{
    public int? EnvironmentId { get; set; }
    public string Type { get; set; } = null!;
    
    public bool IsRequired { get; set; } = false;
    public virtual SystemEnvironment? Environment { get; set; }
}