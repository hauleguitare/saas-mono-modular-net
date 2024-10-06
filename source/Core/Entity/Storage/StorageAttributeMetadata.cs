﻿namespace Core.Entity.Storage;

public class StorageAttributeMetadata: BaseEntity<int>
{
    public int AttributeId { get; set; }
    public string AttributeType { get; set; } = null!;
    public bool IsRequired { get; set; } = false;
    
    public virtual StorageAttribute? Attribute { get; set; }
}