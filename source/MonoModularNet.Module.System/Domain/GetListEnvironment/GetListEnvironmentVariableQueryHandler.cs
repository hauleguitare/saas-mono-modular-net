using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MonoModularNet.Infrastructure.DAL.System;
using MonoModularNet.Module.System.Domain.Model;

namespace MonoModularNet.Module.System.Domain.GetListEnvironment;

public class GetListEnvironmentVariableQueryHandler: CqrsQueryHandler<GetListEnvironmentVariableQuery, IReadOnlyList<EnvironmentListItemRes>>
{
    private readonly IEntityRepository<SystemEnvironment, int> _systemEnvironmentRepo;
    private readonly IMapper _mapper;

    public GetListEnvironmentVariableQueryHandler(IEntityRepository<SystemEnvironment, int> systemEnvironmentRepo, IMapper mapper)
    {
        _systemEnvironmentRepo = systemEnvironmentRepo;
        _mapper = mapper;
    }

    public override async Task<IReadOnlyList<EnvironmentListItemRes>> Handle(GetListEnvironmentVariableQuery request, CancellationToken cancellationToken)
    {
        var result = await _systemEnvironmentRepo.AsQueryable()
            .ProjectTo<EnvironmentListItemRes>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken: cancellationToken);

        return result;
    }
}