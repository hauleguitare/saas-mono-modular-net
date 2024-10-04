using System.Reflection;
using Core.Entity.System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MonoModularNet.Infrastructure.DAL.Identity;

namespace MonoModularNet.Infrastructure.DAL.Context;

public partial class ApplicationDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    // ------ System ------ //
    public virtual DbSet<SystemConfiguration> SystemConfigurations { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}