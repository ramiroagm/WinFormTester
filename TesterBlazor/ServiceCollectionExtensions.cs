using TesterProject.BusinessLogic.InfoCredito.Nucleos;
using TesterProject.BusinessLogic.InfoCredito.Personas;
using TesterProject.BusinessLogic.Interfaces.InfoCredito;
using TesterProject.BusinessLogic.TelegramBot;

namespace TesterBlazor
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<TelegramConnector>();
            services.AddScoped<IPersonas, PersonasDatabaseInformation>();
            services.AddScoped<INucleos, NucleosDatabaseInformation>();
            return services;
        }
    }
}
