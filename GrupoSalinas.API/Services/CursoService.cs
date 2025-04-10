using GrupoSalinas.API.Data;
using GrupoSalinas.API.DTOs;
using GrupoSalinas.API.Models;
using GrupoSalinas.API.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GrupoSalinas.API.Services.Implementaciones
{
    public class CursoService : ICursoService
    {
        private readonly ApplicationDbContext _context;

        public CursoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Curso>> ObtenerCursos()
        {
            return await _context.Cursos
                .FromSqlRaw("EXEC sp_ObtenerCursos")
                .ToListAsync();
        }

        public async Task<Curso> ObtenerCursoPorId(int id)
        {
            var cursos = await _context.Cursos
                .FromSqlRaw("EXEC sp_ObtenerCursoPorId @Id", new SqlParameter("@Id", id))
                .ToListAsync();

            return cursos.FirstOrDefault();
        }

        public async Task<bool> InsertarCurso(CursoDTO dto)
        {
            var sql = "EXEC sp_InsertarCurso @Nombre, @Descripcion, @Codigo";

            int rows = await _context.Database.ExecuteSqlRawAsync(
                sql,
                new SqlParameter("@Nombre", dto.Nombre),
                new SqlParameter("@Descripcion", dto.Descripcion),
                new SqlParameter("@Codigo", dto.Codigo)
            );

            return rows > 0;
        }

        public async Task<bool> ActualizarCurso(int id, CursoDTO dto)
        {
            var sql = "EXEC sp_ActualizarCurso @Id, @Nombre, @Descripcion, @Codigo";

            int rows = await _context.Database.ExecuteSqlRawAsync(
                sql,
                new SqlParameter("@Id", id),
                new SqlParameter("@Nombre", dto.Nombre),
                new SqlParameter("@Descripcion", dto.Descripcion),
                new SqlParameter("@Codigo", dto.Codigo)
            );

            return rows > 0;
        }

        public async Task<bool> EliminarCurso(int id)
        {
            int rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_EliminarCurso @Id",
                new SqlParameter("@Id", id)
            );

            return rows > 0;
        }
    }
}
