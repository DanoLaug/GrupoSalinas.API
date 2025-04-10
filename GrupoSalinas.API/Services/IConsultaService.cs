using GrupoSalinas.API.DTOs;

namespace GrupoSalinas.API.Services.Interfaces
{
    public interface IConsultaService
    {
        Task<List<ConsultaCursoConAlumnosDTO>> ObtenerAlumnosPorCurso(int cursoId);
        Task<List<ConsultaCursosPorProfesorDTO>> ObtenerCursosPorProfesor(int profesorId);
    }
}
