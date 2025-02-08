using Dapper;
using JobPortal.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JobPortal.Infrastructure.Repository
{
    public class DapperRepository<T> : IDapperRepository<T> where T : class
    {
        private readonly string _connectionString;

        public DapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<T>> GetAllAsync(string query)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<T>(query);
            }
        }

        public async Task<T> GetByIdAsync(string query, object parameters)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<T>(query, parameters);
            }
        }

        public async Task<IEnumerable<T>> FindAsync(string query, object parameters)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<T>(query, parameters);
            }
        }
    }
}
