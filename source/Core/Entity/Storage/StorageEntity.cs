namespace Core.Entity.Storage;

public class StorageEntity: BaseEntity<int>
{
    public StorageEntity()
    {
        Metadata = new StorageEntityMetadata();
    }
    
    public string Name { get; set; } = null!;
    
    public StorageEntityMetadata Metadata { get; set; }
}