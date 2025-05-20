using TesterProject.BusinessEntities.Utils;

namespace TesterProject.BusinessLogic.Interfaces.Utils
{
    public interface IUtils
    {
        Task<List<Pais>> ObtenerPaises();
        Task<List<Departamento>> ObtenerDepartamentos(int idPais);
        Task<List<Localidad>> ObtenerLocalidades(int idDepartamento);
    }
}