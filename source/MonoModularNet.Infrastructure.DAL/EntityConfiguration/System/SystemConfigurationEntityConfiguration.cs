using Core.Entity.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MonoModularNet.Infrastructure.DAL.EntityConfiguration.System;

public class SystemConfigurationEntityConfiguration: IEntityTypeConfiguration<SystemConfiguration>
{
    public void Configure(EntityTypeBuilder<SystemConfiguration> builder)
    {
        builder.HasKey(e => e.Id).HasName("systemconfiguration_pk");

        builder.Property(e => e.Id).HasDefaultValueSql("nextval('systemconfiguration_id_seq'::regclass)");
    }
}