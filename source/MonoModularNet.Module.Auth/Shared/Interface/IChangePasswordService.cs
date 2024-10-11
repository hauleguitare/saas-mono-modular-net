using MonoModularNet.Module.Auth.Domain.Model;

namespace MonoModularNet.Module.Auth.Shared.Interface;

public interface IChangePasswordService
{
    public Task ChangePasswordAsync(ChangePasswordReq req, CancellationToken cancellationToken = default);
}