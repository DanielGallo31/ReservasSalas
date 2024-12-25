using System.Data;
using MySqlConnector;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace salasyreservas.Helpers
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null)
        {
            using (var connection = GetConnection())
            {
                return await connection.QueryAsync<T>(sql, param);
            }
        }
        public async Task<int> ExecuteAsync(string sql, object? param = null)
        {
            using (var connection = GetConnection())
            {
                return await connection.ExecuteAsync(sql, param);
            }
        }
    }
}