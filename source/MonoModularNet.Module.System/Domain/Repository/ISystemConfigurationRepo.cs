using MonoModularNet.Module.System.Domain.Model;

namespace MonoModularNet.Module.System.Domain.Repository;

public interface ISystemConfigurationRepo
{
    public Task<IReadOnlyList<ConfigurationRes>> GetListAsync(string? orderByColumn = null, string? orderBy = "esc");
}