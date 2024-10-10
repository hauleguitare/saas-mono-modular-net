namespace MonoModularNet.Module.System.Domain.DeleteEnvironment;

public class DeleteEnvironmentCommandHandler: CqrsCommandHandler<DeleteEnvironmentCommand>
{
    private readonly IEntityRepository<SystemEnvironment, int> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEnvironmentCommandHandler(IEntityRepository<SystemEnvironment, int> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public override Task<CqrsResult> Handle(DeleteEnvironmentCommand request, CancellationToken cancellationToken)
    {
        _repository.Remove(request.Id);

        _unitOfWork.SaveChanges();

        return Task.FromResult(CqrsResult.Success());
    }
}