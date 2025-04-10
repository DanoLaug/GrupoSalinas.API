using GrupoSalinas.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrupoSalinas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaService _consultaService;

        public ConsultasController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        // GET: api/Consultas/AlumnosPorCurso/1
        [HttpGet("AlumnosPorCurso/{cursoId}")]
        public async Task<IActionResult> AlumnosPorCurso(int cursoId)
        {
            var result = await _consultaService.ObtenerAlumnosPorCurso(cursoId);
            return Ok(result);
        }

        // GET: api/Consultas/CursosPorProfesor/1
        [HttpGet("CursosPorProfesor/{profesorId}")]
        public async Task<IActionResult> CursosPorProfesor(int profesorId)
        {
            var result = await _consultaService.ObtenerCursosPorProfesor(profesorId);
            return Ok(result);
        }
    }
}
