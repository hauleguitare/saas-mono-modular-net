using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MonoModularNet.Infrastructure.DAL.Notification;
using MonoModularNet.Infrastructure.Shared.Common.Service;

namespace MonoModularNet.Infrastructure.DAL.EntityConfiguration.System;

public class SystemNotificationTypeConfiguration: IEntityTypeConfiguration<SystemNotification>
{

    public SystemNotificationTypeConfiguration(ICurrentUserService currentUserService)
    {
    }

    public void Configure(EntityTypeBuilder<SystemNotification> builder)
    {
        builder.HasIndex(p => p.UserId).HasDatabaseName("AppNotification_UserId_idx");
    }
}