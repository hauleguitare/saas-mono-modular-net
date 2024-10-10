using Core.Exception.System;

namespace MonoModularNet.Module.System.Domain.PatchUpdateEnvironment;

public class PatchUpdateEnvironmentCommandHandler: CqrsCommandHandler<PatchUpdateEnvironmentCommand>
{
    private readonly IEntityRepository<SystemEnvironment, int> _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PatchUpdateEnvironmentCommandHandler(IEntityRepository<SystemEnvironment, int> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public override async Task<CqrsResult> Handle(PatchUpdateEnvironmentCommand request, CancellationToken cancellationToken)
    {
        var record = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (record is null)
        {
            throw new SystemEnvironmentNotFound(null, null);
        }

        _mapper.Map(request, record);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return CqrsResult.Success();
    }
}
