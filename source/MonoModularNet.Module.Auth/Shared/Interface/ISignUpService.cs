using MonoModularNet.Module.Auth.Domain.Model;

namespace MonoModularNet.Module.Auth.Shared.Interface;

public interface ISignUpService
{
    public Task SignUpAsync(SignUpReq req, CancellationToken cancellationToken = default);
}