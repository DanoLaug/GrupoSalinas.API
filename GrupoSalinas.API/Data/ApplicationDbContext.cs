using GrupoSalinas.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GrupoSalinas.API.Data
{
    //Heredamos DbContext para crear nuestro puente con la base de datos
    public class ApplicationDbContext : DbContext
    {
        //Inyectamos las configuraciones desde el Program.cs
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        //Tablas mapadas
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<CursoProfesor> CursoProfesores { get; set; }
        public DbSet<CursoAlumno> CursoAlumnos { get; set; }

        //Modelo en donde definimos las relaciones muchos a muchos (CursoAlumno) 
        // y uno a uno (CursoProfesor)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir claves primarias compuestas
            modelBuilder.Entity<CursoAlumno>()
                .HasKey(ca => new { ca.CursoId, ca.AlumnoId });

            modelBuilder.Entity<CursoProfesor>()
                .HasKey(cp => cp.CursoId); // 1 curso → 1 profesor
        }
    }
}

