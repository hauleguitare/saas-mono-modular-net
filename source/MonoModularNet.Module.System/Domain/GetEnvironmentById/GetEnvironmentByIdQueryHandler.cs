using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MonoModularNet.Module.System.Domain.Model;

namespace MonoModularNet.Module.System.Domain.GetEnvironmentById;

public class GetEnvironmentByIdQueryHandler: CqrsQueryHandler<GetEnvironmentByIdQuery, EnvironmentRes?>
{
    private readonly IEntityRepository<SystemEnvironment, int> _repository;
    private readonly IMapper _mapper;

    public GetEnvironmentByIdQueryHandler(IEntityRepository<SystemEnvironment, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public override async Task<EnvironmentRes?> Handle(GetEnvironmentByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.AsQueryable().Where(e => e.Id == request.Id)
            .ProjectTo<EnvironmentRes>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
    }
}