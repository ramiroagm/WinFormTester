namespace TesterProject.BusinessEntities.InfoCredito
{
    public class InfoCreditoPersona
    {
        public required int Documento { get; set; }
        public required string PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public required string PrimerApellido { get; set; }
        public required string SegundoApellido { get; set; }
        public required InfoCreditoDireccionPersona Direccion { get; set; }
        public required DateTime FechaNacimiento { get; set; }
    }
}
