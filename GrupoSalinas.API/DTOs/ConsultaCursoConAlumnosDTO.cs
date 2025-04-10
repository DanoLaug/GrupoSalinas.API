namespace GrupoSalinas.API.DTOs
{
    public class ConsultaCursoConAlumnosDTO
    {
        public string Curso { get; set; }
        public string Profesor { get; set; }
        public List<string> Alumnos { get; set; }
    }
}
