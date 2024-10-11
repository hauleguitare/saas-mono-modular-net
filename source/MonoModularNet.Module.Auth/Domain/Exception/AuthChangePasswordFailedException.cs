using Core.Exception;
using Microsoft.AspNetCore.Http;
using MonoModularNet.Module.Auth.Domain.Const;

namespace MonoModularNet.Module.Auth.Domain.Exception;

public class AuthChangePasswordFailedException: DomainException
{
    public AuthChangePasswordFailedException(string code) : base(
        StatusCodes.Status400BadRequest, new []
        {
            SwitchCode(code)
        }, new []
        {
            "Your operation has occurred problem, something went wrong. Please try again!"
        })
    {
    }

    private static string SwitchCode(string code)
    {
        switch (code)
        {
            case "PasswordMismatch":
                return DomainExceptionError.PasswordMisMatched;
            
            default:
                return DomainExceptionError.ChangePasswordFailed;
        }
    }
}