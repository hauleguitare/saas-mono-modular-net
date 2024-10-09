using Core.Entity.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MonoModularNet.Infrastructure.DAL.EntityConfiguration.System;

public class SystemEnvironmentConfiguration: IEntityTypeConfiguration<SystemEnvironment>
{
    public void Configure(EntityTypeBuilder<SystemEnvironment> builder)
    {
        builder.HasKey(e => e.Id).HasName("system_environment_pk");

        builder.HasIndex(e => e.Key).IsUnique().HasDatabaseName("system_environments_uk");

        builder.Property(e => e.Id).HasDefaultValueSql("nextval('system_environment_id_seq'::regclass)");
    }
}