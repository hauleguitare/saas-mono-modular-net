using System.Text;
using Microsoft.Extensions.DependencyInjection;
using MonoModularNet.Infrastructure.DAL.Context;
using MonoModularNet.Infrastructure.DAL.Repository;
using MonoModularNet.Infrastructure.Shared.Common.Attribute;
using MonoModularNet.Module.System.Domain.Model;
using MonoModularNet.Module.System.Domain.Repository;

namespace MonoModularNet.Module.System.Infrastructure.Repository;

[Injectable(InterfaceType = typeof(ISystemConfigurationRepo), Lifetime = ServiceLifetime.Scoped)]
public class SystemConfigurationDapperRepository: DapperRepository, ISystemConfigurationRepo
{
    
    public SystemConfigurationDapperRepository(IDapperContext context) : base(context)
    {
    }
    
    public async Task<IReadOnlyList<ConfigurationRes>> GetListAsync(string? orderByColumn = null, string? orderBy = "esc")
    {
        var testSqlBuilder = new StringBuilder();

        testSqlBuilder = AddTableName(testSqlBuilder, "SystemConfigurations");
        
        var sqlBuilder = new StringBuilder($"""
                                            SELECT * from  "SystemConfigurations"
                                            """);

        if (!string.IsNullOrEmpty(orderByColumn) && !string.IsNullOrEmpty(orderBy))
        {
            sqlBuilder.Append($"ORDER BY \"{orderByColumn}\"");

            if (orderBy == "desc")
            {
                sqlBuilder.Append($" {orderBy}");
            }
        }
        
        var sql = sqlBuilder.ToString();
        var result = await Context.QueryAsync<ConfigurationRes>(sql);

        var resp = result.Select(e => new ConfigurationRes()
        {
            Id = e.Id,
            Value = Convert.ChangeType(e.Value, Type.GetType(e.Type)),
            Key = e.Key,
            Type = e.Type
        });

        return resp.ToList();
    }
}