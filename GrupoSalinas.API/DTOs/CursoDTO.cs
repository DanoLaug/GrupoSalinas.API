namespace GrupoSalinas.API.DTOs
{
    //Data Transfer Object para la tabla Cursos para no exponer al modelo
    //Tambien se usa para no mostrar todas los atributos
    public class CursoDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
    }
}
