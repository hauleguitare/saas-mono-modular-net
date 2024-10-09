using Core.Entity.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MonoModularNet.Infrastructure.DAL.EntityConfiguration.Storage;

public class StorageValueConfiguration: IEntityTypeConfiguration<StorageValue>
{
    public void Configure(EntityTypeBuilder<StorageValue> builder)
    {
        builder.HasKey(e => e.Id).HasName("storage_entity_attribute_value_pk");

        builder.Property(e => e.Id).HasDefaultValueSql("nextval('storage_value_id_seq'::regclass)");

        builder.Property(e => e.Value).HasColumnType("text").IsRequired(false);

        builder.HasOne<StorageEntityAttribute>()
            .WithMany()
            .HasForeignKey(d => d.EntityAttributeId)
            .HasConstraintName("storage_value_entity_attribute_id_storage_entity_fk");
    }
}