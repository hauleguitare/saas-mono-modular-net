using MonoModularNet.Module.System.Domain.CreateEnvironmentVariable;
using MonoModularNet.Module.System.Presentation.Model;

namespace MonoModularNet.Module.System.Infrastructure.Mapper;

public class FromRequestToDomainProfile: Profile
{
    public FromRequestToDomainProfile()
    {
        CreateMap<CreateEnvironmentVariableReq, CreateEnvironmentVariableCommand>();
        CreateMap<CreateEnvironmentVariableMetadataReq, CreateEnvironmentVariableMetadataCommand>();
        
        CreateMap<CreateEnvironmentVariableCommand, SystemEnvironment>();
        CreateMap<CreateEnvironmentVariableMetadataCommand, SystemEnvironmentMetadata>();
    }
}