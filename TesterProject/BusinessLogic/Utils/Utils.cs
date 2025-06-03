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

        public async Task<List<Relacion>> ObtenerRelaciones()
        {
            List<Relacion> relaciones = await Personas.ObtenerRelaciones();
            return relaciones;
        }

        public async Task<int> CrearBug(Bug reporte)
        {
            string targetDirectory = ConstantValues.IC_PathToSave;
            Directory.CreateDirectory(targetDirectory);

            if (reporte.Imagenes != null)
            {
                foreach (var file in reporte.Imagenes)
                {
                    if (file?.Imagen != null)
                    {
                        string fileName = file.TextoImagen ?? $"{Guid.NewGuid()}";
                        string filePath = Path.Combine(targetDirectory, fileName);
                        await File.WriteAllBytesAsync(filePath, file.Imagen);
                    }
                }
            }
            return await BugReport.CrearBug(reporte);
        }
    }
}