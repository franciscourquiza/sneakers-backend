using BeIceProyect.Server.Dtos;
using BeIceProyect.Server.Entities;
using BeIceProyect.Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BeIceProyect.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClotheController : ControllerBase
    {
        private readonly ClotheRepository _repository;
        public ClotheController(ClotheRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            Clothe? clothe = await _repository.GetById(id);
            if (clothe == null)
            {
                return NotFound("No se encontraron productos con ese ID.");
            }
            return Ok(clothe);
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var clothes = await _repository.GetByName(name);
            if (clothes == null)
            {
                return NotFound("No se encontraron zapatillas con ese nombre.");
            }
            return Ok(clothes);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAll());
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] EditClotheDto clotheDto)
        {
            if (clotheDto == null)
            {
                return BadRequest("Los datos del producto son inválidos.");
            }
            Clothe createdClothe = await _repository.Create(clotheDto);
            return Ok("Producto creado correctamente.");
        }
        [HttpPut("EditById")]
        public async Task<IActionResult> EditById([FromQuery] int id, [FromBody] EditClotheDto updatedClothe)
        {
            if (updatedClothe == null)
            {
                return BadRequest("Los datos del producto son inválidos.");
            }

            Clothe? clothe = await _repository.EditById(id, updatedClothe);

            if (clothe == null)
                return NotFound($"No se encontró una sneaker con el ID {id}.");

            return Ok(clothe);
        }
        [HttpDelete("DeleteById")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            await _repository.Delete(id);
            return Ok("Producto eliminado correctamente.");
        }
    }
}
