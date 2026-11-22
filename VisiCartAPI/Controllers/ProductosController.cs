using Microsoft.AspNetCore.Mvc;
using VisiCartAPI.Models;
using VisiCartAPI.Repositories;

namespace VisiCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoRepository _productoRepository;

        public ProductosController(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var productos = _productoRepository.ObtenerTodos();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var producto = _productoRepository.ObtenerPorId(id);
            if (producto == null)
            {
                return NotFound($"No se encontró un producto con ID {id}.");
            }
            return Ok(producto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Producto producto)
        {
            _productoRepository.Registrar(producto);
            return Ok("Producto registrado correctamente.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Producto producto)
        {
            var existente = _productoRepository.ObtenerPorId(id);
            if (existente == null)
            {
                return NotFound($"No se encontró un producto con ID {id}.");
            }

            _productoRepository.Actualizar(id, producto);
            return Ok("Producto actualizado correctamente.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existente = _productoRepository.ObtenerPorId(id);
            if (existente == null)
            {
                return NotFound($"No se encontró un producto con ID {id}.");
            }

            _productoRepository.Eliminar(id);
            return Ok("Producto eliminado correctamente.");
        }
    }
}