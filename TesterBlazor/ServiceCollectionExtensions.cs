using TesterBlazor.Models;
using TesterProject.BusinessLogic.InfoCredito.Nucleos;
using TesterProject.BusinessLogic.InfoCredito.Personas;
using TesterProject.BusinessLogic.Interfaces.InfoCredito;
using TesterProject.BusinessLogic.Interfaces.Utils;
using TesterProject.BusinessLogic.TelegramBot;
using TesterProject.BusinessLogic.Utils;
using TesterProject.DataAccess.Utils;

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
            services.AddScoped<SessionState>();
            services.AddScoped<AuthService>();
            return services;
        }
    }
}