using TesterProject.BusinessEntities.InfoCredito;

namespace TesterProject.BusinessLogic.Interfaces.InfoCredito
{
    public interface INucleos
    {
        Task CrearNucleo(InfoCreditoNucleo nucleo);
        Task<List<InfoCreditoPersona>> ObtenerPersonasPorNucleo(int? idNucleo = null, int? documento = null);
        Task<List<InfoCreditoNucleo>> ObtenerNucleos(int? idNucleo = null, int? documento = null);
    }
}