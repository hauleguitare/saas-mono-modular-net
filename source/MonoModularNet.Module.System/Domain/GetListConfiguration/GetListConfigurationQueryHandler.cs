using MonoModularNet.Infrastructure.DAL.Context;
using MonoModularNet.Module.System.Domain.Model;
using MonoModularNet.Module.System.Domain.Repository;

namespace MonoModularNet.Module.System.Domain.GetListConfiguration;

public class GetListConfigurationQueryHandler: CqrsQueryHandler<GetListConfigurationQuery, IReadOnlyList<ConfigurationRes>>
{
    private readonly ISystemConfigurationRepo _systemConfigurationRepo;
    private readonly ApplicationDbContext Context;

    public GetListConfigurationQueryHandler(ISystemConfigurationRepo systemConfigurationRepo, ApplicationDbContext context)
    {
        _systemConfigurationRepo = systemConfigurationRepo;
        Context = context;
    }

    public override async Task<IReadOnlyList<ConfigurationRes>> Handle(GetListConfigurationQuery request, CancellationToken cancellationToken)
    {
        var result = await _systemConfigurationRepo.GetListAsync(orderByColumn: request.OrderByColumn, orderBy: request.OrderBy);

        return result;
    }
}