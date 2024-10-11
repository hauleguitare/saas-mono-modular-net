using Microsoft.EntityFrameworkCore;
using MonoModularNet.Infrastructure.DAL.Notification;

namespace MonoModularNet.Module.System.Domain.GetNotification;

public class GetNotificationQueryHandler: CqrsQueryHandler<GetNotificationQuery, ICollection<SystemNotification>>
{
    private readonly IEntityRepository<SystemNotification, string> _repository;

    public GetNotificationQueryHandler(IEntityRepository<SystemNotification, string> repository)
    {
        _repository = repository;
    }

    public override async Task<ICollection<SystemNotification>> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
    {
        return await _repository.AsQueryable().AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
    }
}