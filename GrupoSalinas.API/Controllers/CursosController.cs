using GrupoSalinas.API.DTOs;
using GrupoSalinas.API.Models;
using GrupoSalinas.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrupoSalinas.API.Controllers
{
    [ApiController]
    //Definimos la ruta base para el controlador
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        //Inyeccion de cursoService por medio de ICursoService
        private readonly ICursoService _cursoService;

        public CursosController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            var cursos = await _cursoService.ObtenerCursos();
            return Ok(cursos);
        }

        // GET: api/Cursos/1 [id]
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _cursoService.ObtenerCursoPorId(id);
            if (curso == null)
                return NotFound();

            return Ok(curso);
        }

        // POST: api/Cursos
        [HttpPost]
        public async Task<IActionResult> CrearCurso([FromBody] CursoDTO cursoDTO)
        {
            var resultado = await _cursoService.InsertarCurso(cursoDTO);
            if (!resultado)
                return BadRequest("No se pudo insertar el curso.");
            return Ok("Curso insertado correctamente.");
        }

        // PUT: api/Cursos/1 [id]
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCurso(int id, [FromBody] CursoDTO cursoDTO)
        {
            var resultado = await _cursoService.ActualizarCurso(id, cursoDTO);
            if (!resultado)
                return BadRequest("No se pudo actualizar el curso.");
            return Ok("Curso actualizado correctamente.");
        }

        // DELETE: api/Cursos/1 [id]
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCurso(int id)
        {
            var resultado = await _cursoService.EliminarCurso(id);
            if (!resultado)
                return BadRequest("No se pudo eliminar el curso.");
            return Ok("Curso eliminado correctamente.");
        }
    }
}

