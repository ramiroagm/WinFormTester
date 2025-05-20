using TesterProject.BusinessEntities.InfoCredito;
using TesterProject.BusinessLogic.Interfaces.InfoCredito;
using TesterProject.DataAccess.InfoCredito;

namespace TesterProject.BusinessLogic.InfoCredito.Personas
{
    public class PersonasDatabaseInformation : IPersonas
    {
        public async Task<bool> CrearPersona(InfoCreditoPersona persona)
        {
            int retorno = await PersonasDb.CrearPersonaAsync(persona);
            return retorno == -1;
        }

        public async Task<List<InfoCreditoPersona>> ObtenerPersonas(int? documento = null)
        {
            List<InfoCreditoPersona>? personas = await PersonasDb.ObtenerPersonas(documento);
            return personas;
        }
    }
}