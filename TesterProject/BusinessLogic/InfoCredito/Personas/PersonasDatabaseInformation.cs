using TesterProject.BusinessEntities.InfoCredito;
using TesterProject.BusinessLogic.Interfaces.InfoCredito;
using TesterProject.DataAccess.InfoCredito;

namespace TesterProject.BusinessLogic.InfoCredito.Personas
{
    public class PersonasDatabaseInformation : IPersonas
    {
        public void CrearPersona(InfoCreditoPersona persona)
        {
            PersonasDb.CrearPersona(persona);
        }

        public async Task<List<InfoCreditoPersona>> ObtenerPersonas(int? documento = null)
        {
            List<InfoCreditoPersona>? personas = await PersonasDb.ObtenerPersonas(documento);
            return personas;
        }
    }
}