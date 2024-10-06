namespace Core.Entity.Storage;

public class StorageEntityAttribute: BaseEntity<int>
{
    public int EntityId { get; set; }
    public int AttributeId { get; set; }
}