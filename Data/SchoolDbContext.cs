using Npgsql;

namespace SchoolManagementSystem.Data
{
    public class SchoolDbContext
    {
        private readonly string _connectionString;

        public SchoolDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
