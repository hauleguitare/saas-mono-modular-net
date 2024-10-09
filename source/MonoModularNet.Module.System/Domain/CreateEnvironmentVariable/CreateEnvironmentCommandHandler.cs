namespace MonoModularNet.Module.System.Domain.CreateEnvironmentVariable;

public class CreateEnvironmentCommandHandler: CqrsCommandHandler<CreateEnvironmentVariableCommand>
{
    private readonly IEntityRepository<SystemEnvironment, int> _systemConfigurationRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateEnvironmentCommandHandler(IEntityRepository<SystemEnvironment, int> systemConfigurationRepo, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _systemConfigurationRepo = systemConfigurationRepo;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public override Task<CqrsResult> Handle(CreateEnvironmentVariableCommand request, CancellationToken cancellationToken)
    {
        var newRow = _mapper.Map<SystemEnvironment>(request);

        _systemConfigurationRepo.AddAsync(newRow, cancellationToken);

        _unitOfWork.SaveChanges();

        return Task.FromResult(new CqrsResult()
        {
            IsSuccess = true
        });
    }
}