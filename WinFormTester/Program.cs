using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Data.SqlClient;
using TesterProyect.BusinessLogic.Interfaces;
using TesterProyect.BusinessLogic.GeneralDemo;

namespace WinFormTester
{
    static class Program
    {
        // TODO: Mask the connection string
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

            Application.Run(new LoginForm(inyectionTester, delegateTester, connectionString));
            //Application.Run(new Form1(inyectionTester, delegateTester));
        }

        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient(_ => new SqlConnection(connectionString));
                    services.AddSingleton<IInyectionTester, InyectionTester>();
                    services.AddSingleton<IDelegateTester, DelegateTester>();
                    //services.AddSignalR();
                });
    }
}