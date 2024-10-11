using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MonoModularNet.Infrastructure.DAL.System;

namespace MonoModularNet.Infrastructure.DAL.EntityConfiguration.System;

public class SystemEnvironmentConfiguration: IEntityTypeConfiguration<SystemEnvironment>
{
    public void Configure(EntityTypeBuilder<SystemEnvironment> builder)
    {
        builder.HasKey(e => e.Id).HasName("system_environment_pk");

        builder.HasIndex(e => e.Key).IsUnique().HasDatabaseName("system_environments_uk");

        builder.Property(e => e.Id).HasDefaultValueSql("nextval('system_environment_id_seq'::regclass)");
        
        builder.OwnsOne(e => e.Metadata)
            .Property(p => p.IsRequired).HasColumnName("Metadata_IsRequired");
        
        builder.OwnsOne(e => e.Metadata)
            .Property(p => p.Type).HasColumnName("Metadata_Type");
    }
}