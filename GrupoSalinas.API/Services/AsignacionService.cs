using GrupoSalinas.API.Data;
using GrupoSalinas.API.DTOs;
using GrupoSalinas.API.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GrupoSalinas.API.Services.Implementaciones
{
    public class AsignacionService : IAsignacionService
    {
        private readonly ApplicationDbContext _context;

        public AsignacionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AsignarProfesor(AsignacionProfesorDTO dto)
        {
            var rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_AsignarProfesor @CursoId, @ProfesorId",
                new SqlParameter("@CursoId", dto.CursoId),
                new SqlParameter("@ProfesorId", dto.ProfesorId)
            );

            return rows > 0;
        }

        public async Task<bool> InscribirAlumno(InscripcionAlumnoDTO dto)
        {
            var rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InscribirAlumno @CursoId, @AlumnoId",
                new SqlParameter("@CursoId", dto.CursoId),
                new SqlParameter("@AlumnoId", dto.AlumnoId)
            );

            return rows > 0;
        }
    }
}
