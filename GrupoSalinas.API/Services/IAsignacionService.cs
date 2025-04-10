using GrupoSalinas.API.DTOs;

namespace GrupoSalinas.API.Services.Interfaces
{
    public interface IAsignacionService
    {
        Task<bool> AsignarProfesor(AsignacionProfesorDTO dto);
        Task<bool> InscribirAlumno(InscripcionAlumnoDTO dto);
    }
}
