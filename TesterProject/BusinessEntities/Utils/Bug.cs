namespace TesterProject.BusinessEntities.Utils
{
    public class Bug
    {
        public required string Titulo { get; set; }
        public string? Mensaje { get; set; }
        public List<ReporteImagenes>? Imagenes { get; set; }
    }
}
