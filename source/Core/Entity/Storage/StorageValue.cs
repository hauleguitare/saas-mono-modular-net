namespace Core.Entity.Storage;

public class StorageValue: BaseEntity<int>
{
    public int EntityAttributeId { get; set; }
    public string? Value { get; set; }
}