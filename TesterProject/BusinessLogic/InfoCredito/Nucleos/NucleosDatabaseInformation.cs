using Serilog.Core;
using TesterProject.BusinessEntities.InfoCredito;
using TesterProject.BusinessLogic.Interfaces.InfoCredito;
using TesterProject.DataAccess.InfoCredito;

namespace TesterProject.BusinessLogic.InfoCredito.Nucleos
{
    public class NucleosDatabaseInformation : INucleos
    {
        public async Task<bool> CrearNucleo(InfoCreditoNucleo nucleo)
        {
            bool retornoValido = false;
            int idNucleo = await NucleosDb.CrearNucleo(nucleo);
            if (idNucleo >= -1)
            {
                if (nucleo.Personas.Count > 0)
                {
                    int countControl = 0;
                    foreach (InfoCreditoPersona persona in nucleo.Personas)
                    {
                        bool ret = await NucleosDb.AgregarPersonaNucleo(persona, idNucleo);
                        if (ret) countControl++;
                    }

                    if (countControl == nucleo.Personas.Count)
                    {
                        retornoValido = true;
                    }
                    else
                    {
                        // TODO: dar log SERILOG y enviar mensaje hacia atrás.
                        //Log.Error("Error al agregar personas al núcleo. Contador: {CountControl}, Personas: {PersonasCount}", countControl, nucleo.Personas.Count);
                        retornoValido = false;
                    }
                }
                else
                {
                    retornoValido =  true;
                }
            }

            return retornoValido;
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