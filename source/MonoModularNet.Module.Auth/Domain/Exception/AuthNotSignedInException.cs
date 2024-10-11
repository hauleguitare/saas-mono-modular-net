using Core.Exception;
using Microsoft.AspNetCore.Http;
using MonoModularNet.Module.Auth.Domain.Const;

namespace MonoModularNet.Module.Auth.Domain.Exception;

public class AuthNotSignedInException: DomainException
{
    public AuthNotSignedInException() : base(StatusCodes.Status400BadRequest, new []
    {
        DomainExceptionError.NotSignedIn
    }, new []
    {
        "you haven't signed in yet, please check again."
    })
    {
    }
}