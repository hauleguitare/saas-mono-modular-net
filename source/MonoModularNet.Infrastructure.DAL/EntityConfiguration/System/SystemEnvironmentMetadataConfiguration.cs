using Core.Entity.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MonoModularNet.Infrastructure.DAL.EntityConfiguration.System;

public class SystemEnvironmentMetadataConfiguration: IEntityTypeConfiguration<SystemEnvironmentMetadata>
{
    public void Configure(EntityTypeBuilder<SystemEnvironmentMetadata> builder)
    {
        builder.HasKey(e => e.Id).HasName("system_environment_metadata_pk");
        
        builder.Property(e => e.Id).HasDefaultValueSql("nextval('system_environment_metadata_id_seq'::regclass)");
        
        builder.Property(e => e.Type)
            .HasColumnType("text")
            .IsRequired();

        builder.HasOne(d => d.Environment)
            .WithOne(p => p.Metadata)
            .HasForeignKey<SystemEnvironmentMetadata>(d => d.EnvironmentId)
            .HasConstraintName("system_environment_metadata_system_environment_id_fk");
    }
}