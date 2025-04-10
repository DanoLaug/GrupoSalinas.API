using GrupoSalinas.API.Data;
using GrupoSalinas.API.DTOs;
using GrupoSalinas.API.Models;
using GrupoSalinas.API.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GrupoSalinas.API.Services.Implementaciones
{
    //Inyeccion de dependencias - ApplicationDbContext
    public class CursoService : ICursoService
    {
        private readonly ApplicationDbContext _context;

        public CursoService(ApplicationDbContext context)
        {
            _context = context;
        }

        //Ejecutamos nuestro procedimiento almacenado sp_ObtenerCursos
        public async Task<List<Curso>> ObtenerCursos()
        {
            return await _context.Cursos
                //Usamos FromSqlRaw para obtener  los datos directamente de la base de datos
                .FromSqlRaw("EXEC sp_ObtenerCursos")
                .ToListAsync();
        }

        //Ejecutamos nuestro procedimiento almacenado sp_ObtenerCursoPorId
        public async Task<Curso> ObtenerCursoPorId(int id)
        {
            var cursos = await _context.Cursos
                .FromSqlRaw("EXEC sp_ObtenerCursoPorId @Id", new SqlParameter("@Id", id))
                .ToListAsync();

            return cursos.FirstOrDefault();
        }

        //Ejecutamos nuestro procedimiento almacenado sp_InsertarCurso
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

        //Ejecutamos nuestro procedimiento almacenado sp_ActualizarCurso
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

        //Ejecutamos nuestro procedimiento almacenado sp_EliminarCurso
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
