using System.Text;

namespace MonoModularNet.Infrastructure.DAL.Repository;

public interface IDapperRepository: IRepository
{
    public StringBuilder AddTableName(StringBuilder sqlBuilder, string tableName);
    public StringBuilder AddWhere(StringBuilder sqlBuilder, string tableName);
}