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

        builder.Property(e => e.AttributeType)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(e => e.IsRequired).HasDefaultValue(false);
    }
}