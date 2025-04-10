using GrupoSalinas.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GrupoSalinas.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<CursoProfesor> CursoProfesores { get; set; }
        public DbSet<CursoAlumno> CursoAlumnos { get; set; }
    }
}

