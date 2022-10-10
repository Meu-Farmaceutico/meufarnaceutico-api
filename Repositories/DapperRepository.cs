using Dapper;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace MeufarmaceuticoApi.Repositories
{
    public class DapperRepository : IDapperRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _conn;

        public DapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _conn = configuration.GetConnectionString("ServerConnection");
        }

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_conn);
            return db.Execute(sp, parms, commandType: commandType);
        }

        public DbConnection GetConnection()
        {
            return new SqlConnection(_conn);
        }

        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;

            using IDbConnection db = new SqlConnection(_conn);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();

                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;

            using IDbConnection db = new SqlConnection(_conn);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();

                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {   
            using IDbConnection db = GetConnection();
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }

        List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = GetConnection();
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }
        
        void Delete<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = GetConnection();
            db.Query<T>(sp, parms, commandType: commandType);
        }

        T IDapperRepository.Get<T>(string sp, DynamicParameters parms, CommandType commandType)
        {
            throw new NotImplementedException();
        }

        List<T> IDapperRepository.GetAll<T>(string sp, DynamicParameters parms, CommandType commandType)
        {
            throw new NotImplementedException();
        }

        bool IDapperRepository.Delete<T>(string sp, DynamicParameters parms, CommandType commandType)
        {
            throw new NotImplementedException();
        }
    }
}
