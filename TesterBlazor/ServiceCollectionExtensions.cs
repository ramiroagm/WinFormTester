using TesterProject.BusinessLogic.InfoCredito.Nucleos;
using TesterProject.BusinessLogic.InfoCredito.Personas;
using TesterProject.BusinessLogic.Interfaces.InfoCredito;
using TesterProject.BusinessLogic.TelegramBot;
using TesterProject.BusinessLogic.Interfaces.Utils;
using TesterProject.BusinessLogic.Utils;

namespace TesterBlazor
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<TelegramConnector>();
            services.AddScoped<IPersonas, PersonasDatabaseInformation>();
            services.AddScoped<INucleos, NucleosDatabaseInformation>();
            services.AddScoped<IUtils, Utils>();

            return services;
        }
    }
}