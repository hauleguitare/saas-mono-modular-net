using Core.Entity.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MonoModularNet.Infrastructure.DAL.EntityConfiguration.Storage;

public class StorageEntityConfiguration: IEntityTypeConfiguration<StorageEntity>
{
    public void Configure(EntityTypeBuilder<StorageEntity> builder)
    {
        builder.HasKey(e => e.Id).HasName("storage_entity_pk");

        builder.Property(e => e.Id).HasDefaultValueSql("nextval('storage_entity_id_seq'::regclass)");
        
        builder.Property(e => e.Name).HasColumnType("text").IsRequired();

        builder.OwnsOne(p => p.Metadata)
            .Property(p => p.IsTemplate).HasColumnName("Metadata_IsTemplate");
    }
}