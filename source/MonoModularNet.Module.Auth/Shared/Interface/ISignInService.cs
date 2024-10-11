using System.Security.Claims;
using MonoModularNet.Module.Auth.Domain.Model;

namespace MonoModularNet.Module.Auth.Shared.Interface;

public interface ISignInService
{
    Task<SignInRes> SignInAsync(SignInReq req, CancellationToken cancellationToken = default);

    Task SignOutAsync(CancellationToken cancellationToken = default);
}