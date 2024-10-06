using Core.Entity.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MonoModularNet.Infrastructure.DAL.EntityConfiguration.Storage;

public class StorageEntityAttributeConfiguration: IEntityTypeConfiguration<StorageEntityAttribute>
{
    public void Configure(EntityTypeBuilder<StorageEntityAttribute> builder)
    {
        builder.HasKey(e => e.Id).HasName("storage_entity_attribute_pk");

        builder.Property(e => e.Id).HasDefaultValueSql("nextval('storage_entity_attribute_id_seq'::regclass)");

        builder.HasOne<StorageEntity>()
            .WithMany()
            .HasForeignKey(d => d.EntityId)
            .HasConstraintName("storage_entity_attribute_entity_id_storage_entity_fk");
        
        builder.HasOne<StorageAttribute>()
            .WithMany()
            .HasForeignKey(d => d.AttributeId)
            .HasConstraintName("storage_entity_attribute_attribute_id_storage_entity_fk");
    }
}