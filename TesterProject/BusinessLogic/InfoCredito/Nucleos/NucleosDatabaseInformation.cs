using Serilog.Core;
using TesterProject.BusinessEntities.InfoCredito;
using TesterProject.BusinessLogic.Interfaces.InfoCredito;
using TesterProject.DataAccess.InfoCredito;

namespace TesterProject.BusinessLogic.InfoCredito.Nucleos
{
    public class NucleosDatabaseInformation : INucleos
    {
        public async Task CrearNucleo(InfoCreditoNucleo nucleo)
        {
            int idNucleo = await NucleosDb.CrearNucleo(nucleo);
            if (idNucleo >= -1)
            {
                foreach (InfoCreditoPersona persona in nucleo.Personas)
                {
                    await NucleosDb.AgregarPersonaNucleo(persona, idNucleo);
                }
            }
            else
            {
                throw new Exception("No se pudo crear el nucleo");
            }
        }

        public async Task<List<InfoCreditoPersona>> ObtenerPersonasPorNucleo(int? idNucleo = null, int? documento = null)
        {
            List<InfoCreditoPersona> personas = await NucleosDb.ObtenerPersonasPorNucleo(idNucleo, documento);
            return personas;
        }

        public async Task<List<InfoCreditoNucleo>> ObtenerNucleos(int? idNucleo = null, int? documento = null)
        {
            return await NucleosDb.ObtenerNucleo(idNucleo, documento);
        }
    }
}