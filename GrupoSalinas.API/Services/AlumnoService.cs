using GrupoSalinas.API.Data;
using GrupoSalinas.API.DTOs;
using GrupoSalinas.API.Models;
using GrupoSalinas.API.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GrupoSalinas.API.Services.Implementaciones
{
    public class AlumnoService : IAlumnoService
    {
        private readonly ApplicationDbContext _context;

        public AlumnoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Alumno>> ObtenerAlumnos()
        {
            return await _context.Alumnos
                .FromSqlRaw("EXEC sp_ObtenerAlumnos")
                .ToListAsync();
        }

        public async Task<Alumno> ObtenerAlumnoPorId(int id)
        {
            var result = await _context.Alumnos
                .FromSqlRaw("EXEC sp_ObtenerAlumnoPorId @Id", new SqlParameter("@Id", id))
                .ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<bool> InsertarAlumno(AlumnoDTO dto)
        {
            var rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertarAlumno @Nombre, @Apellido, @FechaNacimiento, @Identificacion",
                new SqlParameter("@Nombre", dto.Nombre),
                new SqlParameter("@Apellido", dto.Apellido),
                new SqlParameter("@FechaNacimiento", dto.FechaNacimiento),
                new SqlParameter("@Identificacion", dto.Identificacion)
            );

            return rows > 0;
        }

        public async Task<bool> ActualizarAlumno(int id, AlumnoDTO dto)
        {
            var rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_ActualizarAlumno @Id, @Nombre, @Apellido, @FechaNacimiento, @Identificacion",
                new SqlParameter("@Id", id),
                new SqlParameter("@Nombre", dto.Nombre),
                new SqlParameter("@Apellido", dto.Apellido),
                new SqlParameter("@FechaNacimiento", dto.FechaNacimiento),
                new SqlParameter("@Identificacion", dto.Identificacion)
            );

            return rows > 0;
        }

        public async Task<bool> EliminarAlumno(int id)
        {
            var rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_EliminarAlumno @Id",
                new SqlParameter("@Id", id)
            );

            return rows > 0;
        }
    }
}

