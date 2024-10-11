using Core.Exception;
using Microsoft.AspNetCore.Http;
using MonoModularNet.Module.Auth.Domain.Const;

namespace MonoModularNet.Module.Auth.Domain.Exception;

public class AuthSignedInAlreadyException: DomainException
{
    public AuthSignedInAlreadyException() : base(StatusCodes.Status400BadRequest ,new []
    {
        DomainExceptionError.SignedInAlready
    }, new []
    {
        "you've signed in already, please check again."
    })
    {
    }
}