using Microsoft.AspNetCore.Mvc;
using VisiCartAPI.Models;
using VisiCartAPI.Repositories;

namespace VisiCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteRepository _clienteRepository;

        public ClientesController(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var clientes = await _clienteRepository.ListarAsync();
            return Ok(clientes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var cliente = await _clienteRepository.ObtenerPorIdAsync(id);
            if (cliente is null)
            {
                return NotFound($"No se encontró el cliente con ID {id}.");
            }

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] Cliente cliente)
        {
            await _clienteRepository.RegistrarAsync(cliente);
            return Ok("Cliente registrado correctamente.");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Cliente cliente)
        {
            var existente = await _clienteRepository.ObtenerPorIdAsync(id);
            if (existente is null)
            {
                return NotFound($"No se encontró el cliente con ID {id}.");
            }

            cliente.IdCliente = id;
            await _clienteRepository.ActualizarAsync(cliente);
            return Ok("Cliente actualizado correctamente.");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var existente = await _clienteRepository.ObtenerPorIdAsync(id);
            if (existente is null)
            {
                return NotFound($"No se encontró el cliente con ID {id}.");
            }

            await _clienteRepository.EliminarAsync(id);
            return Ok("Cliente eliminado correctamente.");
        }
    }
}