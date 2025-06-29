using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Data.SqlClient;
using TesterProject.BusinessLogic.GeneralDemo;
using TesterProject.BusinessLogic.Instagram;
using TesterProject.BusinessLogic.Interfaces.DelegateTester;
using TesterProject.BusinessLogic.Interfaces.Instagram;
using TesterProject.BusinessLogic.Interfaces.InyectionTester;

namespace WinFormTester
{
    static class Program
    {
        // TODO: Conn String ya inválido
        private static readonly string connectionString = "Data Source=MP200;TrustServerCertificate=True;Integrated Security=SSPI;Initial Catalog=TesterGen";
       
        [STAThread]
        static void Main()
        {
            var host = CreateHostBuilder().Build();
            var services = host.Services;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create an instance of the concrete implementation
            var inyectionTester = services.GetRequiredService<IInyectionTester>();
            var delegateTester = services.GetRequiredService<IDelegateTester>();
            var instagramConnector = services.GetRequiredService<IInstagramConnector>();

            Application.Run(new LoginForm(inyectionTester, delegateTester, instagramConnector, connectionString));
            //Application.Run(new Form1(inyectionTester, delegateTester));
        }

        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient(_ => new SqlConnection(connectionString));
                    services.AddSingleton<IInyectionTester, InyectionTester>();
                    services.AddSingleton<IDelegateTester, DelegateTester>();
                    services.AddSingleton<IInstagramConnector, InstagramConnector>();
                    //services.AddSignalR();
                });
    }
}