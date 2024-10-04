using Core.Entity.System;
using MonoModularNet.Infrastructure.DAL.Repository;
using MonoModularNet.Infrastructure.DAL.UnitOfWork;

namespace MonoModularNet.Module.System.Domain.CreateConfiguration;

public class CreateConfigurationCommandHandler: CqrsCommandHandler<CreateConfigurationCommand>
{
    private readonly IEntityRepository<SystemConfiguration, int> _systemConfigurationRepo;
    private readonly IUnitOfWork _unitOfWork;

    public CreateConfigurationCommandHandler(IEntityRepository<SystemConfiguration, int> systemConfigurationRepo, IUnitOfWork unitOfWork)
    {
        _systemConfigurationRepo = systemConfigurationRepo;
        _unitOfWork = unitOfWork;
    }

    public override Task<CqrsResult> Handle(CreateConfigurationCommand request, CancellationToken cancellationToken)
    {
        var newRow = new SystemConfiguration()
        {
            Key = request.Key,
            Type = request.Type,
            Value = request.Value
        };
        _systemConfigurationRepo.AddAsync(newRow, cancellationToken);

        _unitOfWork.SaveChanges();

        return Task.FromResult(new CqrsResult()
        {
            IsSuccess = true
        });
    }
}