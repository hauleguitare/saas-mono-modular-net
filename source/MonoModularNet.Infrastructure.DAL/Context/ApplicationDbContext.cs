using System.Reflection;
using Core.Entity.Storage;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MonoModularNet.Infrastructure.DAL.Identity;
using MonoModularNet.Infrastructure.DAL.Notification;
using MonoModularNet.Infrastructure.DAL.Seed;
using MonoModularNet.Infrastructure.DAL.System;
using MonoModularNet.Infrastructure.Shared.Common.Service;

namespace MonoModularNet.Infrastructure.DAL.Context;

public partial class ApplicationDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    // ------ System ------ //
    public virtual DbSet<SystemEnvironment> SystemEnvironments { get; set; }
    public DbSet<SystemNotification> SystemNotifications { get; set; }


    // ------ Storage ------ //
    public virtual DbSet<StorageEntity> StorageEntities { get; set; }
    public virtual DbSet<StorageAttribute> StorageAttributes { get; set; }
    public virtual DbSet<StorageEntityAttribute> StorageEntityAttributes { get; set; }
    public virtual DbSet<StorageValue> StorageValues { get; set; }
    // ------ Storage ------ //


    private readonly ICurrentUserService _currentUserService;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService) :
        base(options)
    {
        _currentUserService = currentUserService;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(builder);

        builder.HasSequence<int>("system_environment_id_seq").IncrementsBy(1);
        builder.HasSequence<int>("storage_attribute_id_seq").IncrementsBy(1);
        builder.HasSequence<int>("storage_entity_attribute_id_seq").IncrementsBy(1);
        builder.HasSequence<int>("storage_entity_id_seq").IncrementsBy(1);
        builder.HasSequence<int>("storage_value_id_seq").IncrementsBy(1);

        builder.SeedApplicationUser("admin@root.com", "123456");
        builder.SeedApplicationRoles();
        builder.SeedApplicationRoleClaims();
        builder.SeedApplicationUserRole("owner","owner");


        builder.Entity<SystemNotification>()
            .HasQueryFilter(e => e.UserId == _currentUserService.UserId);
    }
}
