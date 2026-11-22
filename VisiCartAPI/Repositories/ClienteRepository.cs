using System.Data;
using Dapper;
using VisiCartAPI.Data;
using VisiCartAPI.Models;

namespace VisiCartAPI.Repositories
{
    public class ClienteRepository
    {
        private readonly Connection _connection;

        public ClienteRepository(Connection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Cliente>> ListarAsync()
        {
            using var db = _connection.CreateConnection();
            return await db.QueryAsync<Cliente>(
                "sp_ListarClientes",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Cliente?> ObtenerPorIdAsync(int idCliente)
        {
            using var db = _connection.CreateConnection();
            return await db.QueryFirstOrDefaultAsync<Cliente>(
                "sp_ObtenerClientePorId",
                new { IdCliente = idCliente },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> RegistrarAsync(Cliente cliente)
        {
            using var db = _connection.CreateConnection();
            return await db.ExecuteAsync(
                "sp_RegistrarCliente",
                new
                {
                    cliente.Nombre,
                    cliente.Email,
                    cliente.Telefono,
                    cliente.Calle,
                    cliente.Ciudad
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> ActualizarAsync(Cliente cliente)
        {
            using var db = _connection.CreateConnection();
            return await db.ExecuteAsync(
                "sp_ActualizarCliente",
                new
                {
                    cliente.IdCliente,
                    cliente.Nombre,
                    cliente.Email,
                    cliente.Telefono,
                    cliente.Calle,
                    cliente.Ciudad
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> EliminarAsync(int idCliente)
        {
            using var db = _connection.CreateConnection();
            return await db.ExecuteAsync(
                "sp_EliminarCliente",
                new { IdCliente = idCliente },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}