namespace TesterProject.BusinessEntities.Utils
{
    public class Localidad
    {
        public int IdLocalidad { get; set; }
        public required string NombreLocalidad { get; set; }
        public required Departamento Departamento { get; set; }
    }
}