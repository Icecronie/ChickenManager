using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }

        public async Task<int> SaveData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = await connection.ExecuteAsync(sql, parameters);

                return rows;
            }
        }
    }
}
