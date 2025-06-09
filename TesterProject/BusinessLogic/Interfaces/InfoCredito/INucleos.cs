using TesterProject.BusinessEntities.InfoCredito;

namespace TesterProject.BusinessLogic.Interfaces.InfoCredito
{
    public interface INucleos
    {
        Task<bool> CrearNucleo(InfoCreditoNucleo nucleo);
        Task<List<InfoCreditoPersona>> ObtenerPersonasPorNucleo(int? idNucleo = null, int? documento = null);
        Task<List<InfoCreditoNucleo>> ObtenerNucleos(int? idNucleo = null, int? documento = null);
    }
}