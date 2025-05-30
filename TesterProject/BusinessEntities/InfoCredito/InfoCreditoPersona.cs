namespace TesterProject.BusinessEntities.InfoCredito
{
    public class InfoCreditoPersona
    {
        public required int Documento { get; set; }
        public required string PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public required string PrimerApellido { get; set; }
        public required string SegundoApellido { get; set; }
        public InfoCreditoDireccionPersona? Direccion { get; set; }
        public InfoCreditoContactoPersona? Contacto { get; set; }
        public required DateTime FechaNacimiento { get; set; }
        public string NombreCompleto => $"{PrimerNombre} {SegundoNombre} {PrimerApellido} {SegundoApellido}".Trim();
    }
}
