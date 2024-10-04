using MonoModularNet.Module.System.Domain.Model;
using MonoModularNet.Module.System.Domain.Repository;

namespace MonoModularNet.Module.System.Domain.GetListConfiguration;

public class GetListConfigurationQueryHandler: CqrsQueryHandler<GetListConfigurationQuery, IReadOnlyList<ConfigurationRes>>
{
    private readonly ISystemConfigurationRepo _systemConfigurationRepo;

    public GetListConfigurationQueryHandler(ISystemConfigurationRepo systemConfigurationRepo)
    {
        _systemConfigurationRepo = systemConfigurationRepo;
    }

    public override async Task<IReadOnlyList<ConfigurationRes>> Handle(GetListConfigurationQuery request, CancellationToken cancellationToken)
    {
        var result = await _systemConfigurationRepo.GetListAsync(orderByColumn: request.OrderByColumn, orderBy: request.OrderBy);

        return result;
    }
}