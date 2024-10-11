using MediatR;
using MonoModularNet.Infrastructure.DAL.Repository;
using MonoModularNet.Infrastructure.DAL.UnitOfWork;
using MonoModularNet.Module.Shared.Common.Event;

namespace MonoModularNet.Module.AppNotification.Domain.EventHandler;

public class SystemNotificationEventHandler: INotificationHandler<SystemNotificationEvent>
{
    private readonly IEntityRepository<MonoModularNet.Infrastructure.DAL.Notification.SystemNotification, string> _appNotificationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SystemNotificationEventHandler(IEntityRepository<MonoModularNet.Infrastructure.DAL.Notification.SystemNotification, string> appNotificationRepository, IUnitOfWork unitOfWork)
    {
        _appNotificationRepository = appNotificationRepository;
        _unitOfWork = unitOfWork;
    }

    public Task Handle(SystemNotificationEvent notification, CancellationToken cancellationToken)
    {
        var appNotification =
            new MonoModularNet.Infrastructure.DAL.Notification.SystemNotification(notification.UserId,
                notification.Content, notification.NotifiedAt, notification.From);
        _appNotificationRepository.AddAsync(appNotification, cancellationToken);

        _unitOfWork.SaveChanges();

        return Task.CompletedTask;
    }
}