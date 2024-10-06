using Core.Entity.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MonoModularNet.Infrastructure.DAL.EntityConfiguration.Storage;

public class StorageEntityMetadataConfiguration: IEntityTypeConfiguration<StorageEntityMetadata>
{
    public void Configure(EntityTypeBuilder<StorageEntityMetadata> builder)
    {
        builder.HasKey(e => e.Id).HasName("storage_entity_metadata_pk");

        builder.Property(e => e.Id).HasDefaultValueSql("nextval('storage_entity_metadata_id_seq'::regclass)");
        
        builder.Property(e => e.IsTemplate).HasDefaultValue(false);
    }
}