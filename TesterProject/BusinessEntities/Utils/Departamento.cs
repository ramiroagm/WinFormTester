namespace TesterProject.BusinessEntities.Utils
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public required string NombreDepartamento { get; set; }
        public Pais? Pais { get; set; }
    }
}