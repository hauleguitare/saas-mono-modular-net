using Core.Common.Entity;

namespace Core.Entity.Storage;

public class StorageEntityMetadata: ValueObject
{
    public bool IsTemplate { get; set; } = false;
    public virtual StorageEntity? Entity { get; set; }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return IsTemplate;
    }
}