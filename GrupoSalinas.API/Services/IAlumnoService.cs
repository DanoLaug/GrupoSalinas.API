using GrupoSalinas.API.DTOs;
using GrupoSalinas.API.Models;

namespace GrupoSalinas.API.Services.Interfaces
{
    public interface IAlumnoService
    {
        Task<List<Alumno>> ObtenerAlumnos();
        Task<Alumno> ObtenerAlumnoPorId(int id);
        Task<bool> InsertarAlumno(AlumnoDTO dto);
        Task<bool> ActualizarAlumno(int id, AlumnoDTO dto);
        Task<bool> EliminarAlumno(int id);
    }
}

