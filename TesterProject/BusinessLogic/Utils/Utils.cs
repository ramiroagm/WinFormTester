using TesterProject.BusinessEntities.Utils;
using TesterProject.BusinessLogic.Interfaces.Utils;
using TesterProject.DataAccess.Utils;

namespace TesterProject.BusinessLogic.Utils
{
    public class Utils : IUtils
    {
        public async Task<List<Pais>> ObtenerPaises()
        {
            List<Pais> paises = await Ubicacion.ObtenerPaises();
            return paises;
        }

        public async Task<List<Departamento>> ObtenerDepartamentos(int idPais)
        {
            List<Departamento> departamentos = await Ubicacion.ObtenerDepartamentos(idPais);
            return departamentos;
        }

        public async Task<List<Localidad>> ObtenerLocalidades(int idDepartamento)
        {
            List<Localidad> localidades = await Ubicacion.ObtenerLocalidades(idDepartamento);
            return localidades;
        }
    }
}