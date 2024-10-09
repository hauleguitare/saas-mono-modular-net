using Core.Entity.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MonoModularNet.Infrastructure.DAL.EntityConfiguration.Storage;

public class StorageAttributeMetadataConfiguration: IEntityTypeConfiguration<StorageAttributeMetadata>
{
    public void Configure(EntityTypeBuilder<StorageAttributeMetadata> builder)
    {
        builder.HasKey(e => e.Id).HasName("storage_attribute_metadata_pk");

        builder.Property(e => e.Id).HasDefaultValueSql("nextval('storage_attribute_metadata_id_seq'::regclass)");

        builder.Property(e => e.Type)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(e => e.IsRequired).HasDefaultValue(false);
        
        builder.HasOne(d => d.Attribute)
            .WithOne(p => p.Metadata)
            .HasForeignKey<StorageAttributeMetadata>(p => p.AttributeId)
            .HasConstraintName("storage_attribute_metadata_id_storage_attribute_fk");
    }
}