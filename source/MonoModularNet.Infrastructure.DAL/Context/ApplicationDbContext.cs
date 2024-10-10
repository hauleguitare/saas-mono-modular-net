using System.Reflection;
using Core.Entity.Storage;
using Core.Entity.System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MonoModularNet.Infrastructure.DAL.Identity;

namespace MonoModularNet.Infrastructure.DAL.Context;

public partial class ApplicationDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    // ------ System ------ //
    public virtual DbSet<SystemEnvironment> SystemEnvironments { get; set; }

    // ------ Storage ------ //
    public virtual DbSet<StorageEntity> StorageEntities { get; set; }
    public virtual DbSet<StorageAttribute> StorageAttributes { get; set; }
    public virtual DbSet<StorageEntityAttribute> StorageEntityAttributes { get; set; }
    public virtual DbSet<StorageValue> StorageValues { get; set; }
    // ------ Storage ------ //
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.HasSequence<int>("system_environment_id_seq").IncrementsBy(1);
        builder.HasSequence<int>("storage_attribute_id_seq").IncrementsBy(1);
        builder.HasSequence<int>("storage_entity_attribute_id_seq").IncrementsBy(1);
        builder.HasSequence<int>("storage_entity_id_seq").IncrementsBy(1);
        builder.HasSequence<int>("storage_value_id_seq").IncrementsBy(1);
        
        base.OnModelCreating(builder);
    }
}