using Core.Common.Entity;

namespace Core.Entity.Storage;

public class StorageAttributeMetadata: ValueObject
{
    public string Type { get; set; } = null!;
    public bool IsRequired { get; set; } = false;
    
    public virtual StorageAttribute? Attribute { get; set; }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Type;
        yield return IsRequired;
    }
}