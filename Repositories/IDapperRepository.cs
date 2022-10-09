using Dapper;
using System.Data.Enum;
using System.Data.Common;

namespace MeufarmaceuticoApi.Repositories
{
    public interface IDapperRepository
    {
        DbConnection GetConnection();

        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = commandType.StoredProcedure);

        Enumerable<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = commandType.StoredProcedure);

        T Delete<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
    }
}
