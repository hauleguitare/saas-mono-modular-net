using MonoModularNet.Infrastructure.DAL.System;
using MonoModularNet.Module.System.Domain.CreateEnvironment;
using MonoModularNet.Module.System.Domain.PatchUpdateEnvironment;

namespace MonoModularNet.Module.System.Infrastructure.Mapper;

public class FromCommandToDomainProfile: Profile
{
    public FromCommandToDomainProfile()
    {
        // Create Environment
        CreateMap<CreateEnvironmentCommand, SystemEnvironment>();
        CreateMap<CreateEnvironmentMetadataCommand, SystemEnvironmentMetadata>();
        
        // Patch Update Environment
        CreateMap<PatchUpdateEnvironmentCommand, SystemEnvironment>()
            .ForMember(
                dto => dto.Value,
                conf => conf.MapFrom(
                    (ol) => !string.IsNullOrEmpty(ol.Value) ? ol.Value.ToString() : String.Empty
                )
            ).ForAllMembers(opt => 
                opt.Condition((src, dest, srcMember)=> srcMember != null));
        CreateMap<PatchUpdateEnvironmentMetadataCommand, SystemEnvironmentMetadata>();
    }
}