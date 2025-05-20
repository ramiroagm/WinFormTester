using TesterProject.BusinessEntities.Utils;

namespace TesterProject.BusinessEntities.InfoCredito
{
    public class InfoCreditoDireccionPersona
    {
        public int IdDireccion { get; set; }
        public required Localidad Localidad { get; set; }
        public string? Calle { get; set; }
        public int Numero { get; set; }
        public int Manzana { get; set; }
        public int Solar { get; set; }
        public string Observaciones { get; set; }
    }
}
