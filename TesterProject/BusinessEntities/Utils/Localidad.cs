namespace TesterProject.BusinessEntities.Utils
{
    public class Localidad
    {
        public int IdLocalidad { get; set; }
        public required string NombreLocalidad { get; set; }
        public Departamento? Departamento { get; set; }
    }
}