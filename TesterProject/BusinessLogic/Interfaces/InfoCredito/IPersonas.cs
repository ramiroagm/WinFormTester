using TesterProject.BusinessEntities.InfoCredito;

namespace TesterProject.BusinessLogic.Interfaces.InfoCredito
{
    public interface IPersonas
    {
        void CrearPersona(InfoCreditoPersona persona);
        Task<List<InfoCreditoPersona>> ObtenerPersonas(int? documento = null);
    }
}