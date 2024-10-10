using MonoModularNet.Module.System.Domain.CreateEnvironment;
using MonoModularNet.Module.System.Domain.PatchUpdateEnvironment;
using MonoModularNet.Module.System.Presentation.Model;

namespace MonoModularNet.Module.System.Infrastructure.Mapper;

public class FromRequestToCommandProfile: Profile
{
    public FromRequestToCommandProfile()
    {
        // Create Environment
        CreateMap<CreateEnvironmentReq, CreateEnvironmentCommand>();
        CreateMap<CreateEnvironmentMetadataReq, CreateEnvironmentMetadataCommand>();
        
        // Patch Update Environment
        CreateMap<PatchUpdateEnvironmentReq, PatchUpdateEnvironmentCommand>();
        CreateMap<PatchUpdateEnvironmentMetadataReq, PatchUpdateEnvironmentMetadataCommand>();
    }
}