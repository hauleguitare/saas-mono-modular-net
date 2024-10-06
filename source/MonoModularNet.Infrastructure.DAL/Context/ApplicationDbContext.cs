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
    public virtual DbSet<SystemConfiguration> SystemConfigurations { get; set; }

    // ------ Storage ------ //
    public virtual DbSet<StorageEntity> StorageEntities { get; set; }
    public virtual DbSet<StorageAttribute> StorageAttributes { get; set; }
    public virtual DbSet<StorageEntityAttribute> StorageEntityAttributes { get; set; }
    public virtual DbSet<StorageValue> StorageValues { get; set; }
    public virtual DbSet<StorageEntityMetadata> StorageEntityMetadata { get; set; }
    public virtual DbSet<StorageAttributeMetadata> StorageAttributeMetadata { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}