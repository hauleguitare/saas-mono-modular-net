using Core.Entity.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MonoModularNet.Infrastructure.DAL.EntityConfiguration.Storage;

public class StorageAttributeConfiguration: IEntityTypeConfiguration<StorageAttribute>
{
    public void Configure(EntityTypeBuilder<StorageAttribute> builder)
    {
        builder.HasKey(e => e.Id).HasName("storage_attribute_pk");

        builder.Property(e => e.Id).HasDefaultValueSql("nextval('storage_attribute_id_seq'::regclass)");

        builder.Property(e => e.Name).HasColumnType("text").IsRequired();

        builder.OwnsOne(e => e.Metadata)
            .Property(p => p.IsRequired).HasColumnName("Metadata_IsRequired");
        
        builder.OwnsOne(e => e.Metadata)
            .Property(p => p.Type).HasColumnName("Metadata_Type");
    }
}