using AutoMapper;
using MonoModularNet.Infrastructure.DAL.System;
using MonoModularNet.Module.System.Domain.Model;

namespace MonoModularNet.Module.System.Infrastructure.Mapper;

public class FromDomainToResponseProfile: Profile
{
    public FromDomainToResponseProfile()
    {
        CreateMap<SystemEnvironment, EnvironmentListItemRes>()
            .ForMember(
                dto => dto.Value,
                conf => conf.MapFrom(
                    (ol) => Convert.ChangeType(ol.Value, Type.GetType(ol.Metadata.Type ?? "System.String")!)
                )
            );
        CreateMap<SystemEnvironment, EnvironmentRes>()
            .ForMember(
                dto => dto.Value,
                conf => conf.MapFrom(
                    (ol) => Convert.ChangeType(ol.Value, Type.GetType(ol.Metadata.Type ?? "System.String")!)
                )
            );
        CreateMap<SystemEnvironmentMetadata, EnvironmentMetadataRes>();
    }
}