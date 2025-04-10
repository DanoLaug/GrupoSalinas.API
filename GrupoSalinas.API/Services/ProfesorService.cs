using GrupoSalinas.API.Data;
using GrupoSalinas.API.DTOs;
using GrupoSalinas.API.Models;
using GrupoSalinas.API.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GrupoSalinas.API.Services.Implementaciones
{
    public class ProfesorService : IProfesorService
    {
        private readonly ApplicationDbContext _context;

        public ProfesorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Profesor>> ObtenerProfesores()
        {
            return await _context.Profesores
                .FromSqlRaw("EXEC sp_ObtenerProfesores")
                .ToListAsync();
        }

        public async Task<Profesor> ObtenerProfesorPorId(int id)
        {
            var result = await _context.Profesores
                .FromSqlRaw("EXEC sp_ObtenerProfesorPorId @Id", new SqlParameter("@Id", id))
                .ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<bool> InsertarProfesor(ProfesorDTO dto)
        {
            var rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertarProfesor @Nombre, @Apellido, @Identificacion",
                new SqlParameter("@Nombre", dto.Nombre),
                new SqlParameter("@Apellido", dto.Apellido),
                new SqlParameter("@Identificacion", dto.Identificacion)
            );

            return rows > 0;
        }

        public async Task<bool> ActualizarProfesor(int id, ProfesorDTO dto)
        {
            var rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_ActualizarProfesor @Id, @Nombre, @Apellido, @Identificacion",
                new SqlParameter("@Id", id),
                new SqlParameter("@Nombre", dto.Nombre),
                new SqlParameter("@Apellido", dto.Apellido),
                new SqlParameter("@Identificacion", dto.Identificacion)
            );

            return rows > 0;
        }

        public async Task<bool> EliminarProfesor(int id)
        {
            var rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_EliminarProfesor @Id",
                new SqlParameter("@Id", id)
            );

            return rows > 0;
        }
    }
}
