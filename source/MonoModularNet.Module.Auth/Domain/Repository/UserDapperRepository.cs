using Microsoft.Extensions.DependencyInjection;
using MonoModularNet.Infrastructure.DAL.Context;
using MonoModularNet.Infrastructure.DAL.Repository;
using MonoModularNet.Module.Auth.Domain.Model;
using SharedKernel.Common.Attribute;

namespace MonoModularNet.Module.Auth.Domain.Repository;

public interface IApplicationUserDapperRepository : IDapperRepository
{
    public Task<IReadOnlyList<UserRes>> GetUsersAsync();
}


[Injectable(InterfaceType = typeof(IApplicationUserDapperRepository), Lifetime = ServiceLifetime.Scoped)]
public class ApplicationUserDapperRepository: DapperRepository, IApplicationUserDapperRepository
{
    public ApplicationUserDapperRepository(IDapperContext context) : base(context)
    {
    }

    public Task<IReadOnlyList<UserRes>> GetUsersAsync()
    {
        var sql = $"SELECT * from \"AspNetUsers\"";
        return Context.QueryAsync<UserRes>(sql: sql);
    }
}