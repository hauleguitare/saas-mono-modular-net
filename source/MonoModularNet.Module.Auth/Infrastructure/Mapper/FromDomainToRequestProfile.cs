using AutoMapper;
using MonoModularNet.Module.Auth.Domain.Model;

namespace MonoModularNet.Module.Auth.Infrastructure.Mapper;

public class FromDomainToRequestProfile: Profile
{
    public FromDomainToRequestProfile()
    {
        CreateMap<ApplicationUser, SignInRes>();
    }
}