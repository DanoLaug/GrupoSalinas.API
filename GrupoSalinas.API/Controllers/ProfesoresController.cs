using GrupoSalinas.API.DTOs;
using GrupoSalinas.API.Models;
using GrupoSalinas.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrupoSalinas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesoresController : ControllerBase
    {
        private readonly IProfesorService _profesorService;

        public ProfesoresController(IProfesorService profesorService)
        {
            _profesorService = profesorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesor>>> Get()
        {
            var profesores = await _profesorService.ObtenerProfesores();
            return Ok(profesores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> Get(int id)
        {
            var profesor = await _profesorService.ObtenerProfesorPorId(id);
            if (profesor == null) return NotFound();
            return Ok(profesor);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProfesorDTO dto)
        {
            var ok = await _profesorService.InsertarProfesor(dto);
            return ok ? Ok("Profesor creado.") : BadRequest("No se pudo crear el profesor.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProfesorDTO dto)
        {
            var ok = await _profesorService.ActualizarProfesor(id, dto);
            return ok ? Ok("Profesor actualizado.") : BadRequest("No se pudo actualizar.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _profesorService.EliminarProfesor(id);
            return ok ? Ok("Profesor eliminado.") : BadRequest("No se pudo eliminar.");
        }
    }
}
