using TesterProject.BusinessEntities.InfoCredito;
using TesterProject.BusinessLogic.Interfaces.InfoCredito;
using TesterProject.DataAccess.InfoCredito;

namespace TesterProject.BusinessLogic.InfoCredito.Nucleos
{
    public class NucleosDatabaseInformation : INucleos
    {
        public void CrearNucleo(InfoCreditoNucleo nucleo)
        {
            NucleosDb.CrearNucleo(nucleo);
        }

        public async Task<List<InfoCreditoPersona>> ObtenerPersonasPorNucleo(int? idNucleo = null, int? documento = null)
        {
            List<InfoCreditoPersona> personas = await NucleosDb.ObtenerNucleos(idNucleo, documento);
            return personas;
        }
    }
}