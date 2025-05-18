namespace TesterBlazor.Models.InfoCredito
{
    public class Nucleo
    {
        public int IdNucleo { get; set; }
        public required TipoRelacion Relacion { get; set; }
        public required List<Persona> Personas { get; set; }
        public string? Comentarios { get; set; }
    }
}
