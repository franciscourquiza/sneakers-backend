using BeIceProyect.Server.Dtos;
using BeIceProyect.Server.Entities;
using BeIceProyect.Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BeIceProyect.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapController : ControllerBase
    {
        private readonly CapRepository _repository;
        public CapController(CapRepository repository) 
        {
            _repository = repository;
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            Cap? cap = await _repository.GetById(id);
            if (cap == null)
            {
                return NotFound("No se encontraron zapatillas con ese ID.");
            }
            return Ok(cap);
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var cap = await _repository.GetByName(name);
            if (cap == null)
            {
                return NotFound("No se encontraron zapatillas con ese nombre.");
            }
            return Ok(cap);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAll());
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] EditCapDto capDto)
        {
            if (capDto == null)
            {
                return BadRequest("Los datos del producto son inválidos.");
            }
            Cap createdCap = await _repository.Create(capDto);
            return Ok("Producto creado correctamente.");
        }
        [HttpPut("EditById")]
        public async Task<IActionResult> EditById([FromQuery] int id, [FromBody] EditCapDto updatedCap)
        {
            if (updatedCap == null)
            {
                return BadRequest("Los datos del producto son inválidos.");
            }

            Cap? cap = await _repository.EditById(id, updatedCap);

            if (cap == null)
                return NotFound($"No se encontró una sneaker con el ID {id}.");

            return Ok(cap);
        }
        [HttpDelete("DeleteById")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            await _repository.Delete(id);
            return Ok("Producto eliminado correctamente.");
        }
    }
}
