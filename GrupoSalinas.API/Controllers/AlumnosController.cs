using GrupoSalinas.API.DTOs;
using GrupoSalinas.API.Models;
using GrupoSalinas.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrupoSalinas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnosController : ControllerBase
    {
        private readonly IAlumnoService _alumnoService;

        public AlumnosController(IAlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alumno>>> Get()
        {
            var alumnos = await _alumnoService.ObtenerAlumnos();
            return Ok(alumnos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alumno>> Get(int id)
        {
            var alumno = await _alumnoService.ObtenerAlumnoPorId(id);
            if (alumno == null) return NotFound();
            return Ok(alumno);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AlumnoDTO dto)
        {
            var ok = await _alumnoService.InsertarAlumno(dto);
            return ok ? Ok("Alumno creado.") : BadRequest("No se pudo crear el alumno.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AlumnoDTO dto)
        {
            var ok = await _alumnoService.ActualizarAlumno(id, dto);
            return ok ? Ok("Alumno actualizado.") : BadRequest("No se pudo actualizar.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _alumnoService.EliminarAlumno(id);
            return ok ? Ok("Alumno eliminado.") : BadRequest("No se pudo eliminar.");
        }
    }
}

