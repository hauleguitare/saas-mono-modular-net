using System.Text;
using MonoModularNet.Infrastructure.DAL.Context;

namespace MonoModularNet.Infrastructure.DAL.Repository;

public abstract class DapperRepository: IDapperRepository
{
    protected IDapperContext Context { get; }
    
    
    private bool _disposed = false;

    protected DapperRepository(IDapperContext context)
    {
        Context = context;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                //TODO:
                // Implement context dispose here
            }
        }
        _disposed = true;
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public StringBuilder AddTableName(StringBuilder sqlBuilder, string tableName)
    {
        return sqlBuilder.Append($"{tableName} ");
    }

    public StringBuilder AddWhere(StringBuilder sqlBuilder, string tableName)
    {
        throw new NotImplementedException();
    }
}