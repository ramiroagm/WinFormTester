using TesterProject.BusinessEntities.Utils;

namespace TesterProject.BusinessEntities.InfoCredito
{
    public class InfoCreditoNucleo
    {
        public int IdNucleo { get; set; }
        public required Relacion Relacion { get; set; }
        public required List<InfoCreditoPersona> Personas { get; set; } = [];
    }
}