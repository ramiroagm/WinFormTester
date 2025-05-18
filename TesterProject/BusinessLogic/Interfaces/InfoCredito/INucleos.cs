using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesterProject.BusinessEntities.InfoCredito;

namespace TesterProject.BusinessLogic.Interfaces.InfoCredito
{
    public interface INucleos
    {
        void CrearNucleo(InfoCreditoNucleo nucleo);
        Task<List<InfoCreditoPersona>> ObtenerPersonasPorNucleo(int? idNucleo = null, int? documento = null);
    }
}