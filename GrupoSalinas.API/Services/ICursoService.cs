using GrupoSalinas.API.DTOs;
using GrupoSalinas.API.Models;

namespace GrupoSalinas.API.Services.Interfaces
{
    public interface ICursoService
    {
        Task<List<Curso>> ObtenerCursos();
        Task<Curso> ObtenerCursoPorId(int id);
        Task<bool> InsertarCurso(CursoDTO dto);
        Task<bool> ActualizarCurso(int id, CursoDTO dto);
        Task<bool> EliminarCurso(int id);
    }
}
