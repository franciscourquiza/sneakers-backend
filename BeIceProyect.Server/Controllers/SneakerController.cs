using BeIceProyect.Server.Dtos;
using BeIceProyect.Server.Entities;
using BeIceProyect.Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BeIceProyect.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SneakerController : ControllerBase
    {
        private readonly SneakerRepository _repository;
        public SneakerController(SneakerRepository repository) 
        {
            _repository = repository;
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            Sneaker? sneaker = await _repository.GetById(id);
            if (sneaker == null)
            {
                return NotFound("No se encontraron zapatillas con ese ID.");
            }
            return Ok(sneaker);
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var sneakers = await _repository.GetByName(name);
            if (sneakers == null)
            {
                return NotFound("No se encontraron zapatillas con ese nombre.");
            }
            return Ok(sneakers);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAll());
        }
        [HttpGet("GetBySize")]
        public async Task<IActionResult> GetBySize([FromQuery] int size)
        {
            var sneakers = await _repository.GetBySize(size);
            if (sneakers == null)
            {
                return NotFound("No se encontraron zapatillas con ese talle.");
            }
            return Ok(sneakers);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] EditProductDto sneakerDto)
        {
            if (sneakerDto == null)
            {
                return BadRequest("Los datos del producto son inválidos.");
            }
            Sneaker createdSneaker = await _repository.Create(sneakerDto);
            return Ok("Producto creado correctamente.");
        }
        [HttpPut("EditById")]
        public async Task<IActionResult> EditById([FromQuery] int id, [FromBody] EditProductDto updatedSneaker)
        {
            if (updatedSneaker == null)
            {
                return BadRequest("Los datos del producto son inválidos.");
            }

            Sneaker? sneaker = await _repository.EditById(id, updatedSneaker);

            if (sneaker == null)
                return NotFound($"No se encontró una sneaker con el ID {id}.");

            return Ok(sneaker);
        }
        [HttpDelete("DeleteById")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            await _repository.Delete(id);
            return Ok("Producto eliminado correctamente.");
        }
    }
}
