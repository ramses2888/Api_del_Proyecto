using Microsoft.Data.SqlClient;
using System.Data;

namespace VisiCartAPI.Data
{
    public class Connection
    {
        private readonly string _connectionString;

        public Connection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'DefaultConnection'.");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}