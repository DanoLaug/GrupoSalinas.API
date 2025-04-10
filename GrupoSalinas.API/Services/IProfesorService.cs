using GrupoSalinas.API.DTOs;
using GrupoSalinas.API.Models;

namespace GrupoSalinas.API.Services.Interfaces
{
    public interface IProfesorService
    {
        Task<List<Profesor>> ObtenerProfesores();
        Task<Profesor> ObtenerProfesorPorId(int id);
        Task<bool> InsertarProfesor(ProfesorDTO dto);
        Task<bool> ActualizarProfesor(int id, ProfesorDTO dto);
        Task<bool> EliminarProfesor(int id);
    }
}

