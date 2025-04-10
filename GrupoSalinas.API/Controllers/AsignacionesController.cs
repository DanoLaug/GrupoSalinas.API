using GrupoSalinas.API.DTOs;
using GrupoSalinas.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrupoSalinas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsignacionesController : ControllerBase
    {
        private readonly IAsignacionService _asignacionService;

        public AsignacionesController(IAsignacionService asignacionService)
        {
            _asignacionService = asignacionService;
        }

        // POST: api/Asignaciones/AsignarProfesor
        [HttpPost("AsignarProfesor")]
        public async Task<IActionResult> AsignarProfesor([FromBody] AsignacionProfesorDTO dto)
        {
            var ok = await _asignacionService.AsignarProfesor(dto);
            return ok ? Ok("Profesor asignado al curso.") : BadRequest("No se pudo asignar.");
        }

        // POST: api/Asignaciones/InscribirAlumno
        [HttpPost("InscribirAlumno")]
        public async Task<IActionResult> InscribirAlumno([FromBody] InscripcionAlumnoDTO dto)
        {
            var ok = await _asignacionService.InscribirAlumno(dto);
            return ok ? Ok("Alumno inscrito al curso.") : BadRequest("No se pudo inscribir.");
        }
    }
}
