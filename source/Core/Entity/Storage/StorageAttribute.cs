namespace Core.Entity.Storage;

public class StorageAttribute: BaseEntity<int>
{
    public StorageAttribute()
    {
        Metadata = new StorageAttributeMetadata();
    }
    
    public string Name { get; set; } = null!;
    
    public StorageAttributeMetadata Metadata { get; set; }
}