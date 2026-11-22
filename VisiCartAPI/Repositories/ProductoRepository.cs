using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using VisiCartAPI.Data;
using VisiCartAPI.Models;

namespace VisiCartAPI.Repositories
{
    public class ProductoRepository
    {
        private readonly Connection _connection;

        public ProductoRepository(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            using SqlConnection conn = (SqlConnection)_connection.CreateConnection();
            return conn.Query<Producto>(
                "sp_ListarProductos",
                commandType: CommandType.StoredProcedure
            );
        }

        public Producto? ObtenerPorId(int idProducto)
        {
            using SqlConnection conn = (SqlConnection)_connection.CreateConnection();
            return conn.QueryFirstOrDefault<Producto>(
                "sp_ObtenerProductoPorId",
                new { IdProducto = idProducto },
                commandType: CommandType.StoredProcedure
            );
        }

        public int Registrar(Producto producto)
        {
            using SqlConnection conn = (SqlConnection)_connection.CreateConnection();
            return conn.Execute(
                "sp_RegistrarProducto",
                new
                {
                    producto.Nombre,
                    producto.PrecioCatalogo,
                    producto.PesoEsperado,
                    producto.IdCategoria
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public int Actualizar(int idProducto, Producto producto)
        {
            using SqlConnection conn = (SqlConnection)_connection.CreateConnection();
            return conn.Execute(
                "sp_ActualizarProducto",
                new
                {
                    IdProducto = idProducto,
                    producto.Nombre,
                    producto.PrecioCatalogo,
                    producto.PesoEsperado,
                    producto.IdCategoria
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public int Eliminar(int idProducto)
        {
            using SqlConnection conn = (SqlConnection)_connection.CreateConnection();
            return conn.Execute(
                "sp_EliminarProducto",
                new { IdProducto = idProducto },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}