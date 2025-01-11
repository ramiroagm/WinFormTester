using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TesterProyect;
using TesterProyect.Interfaces;

namespace WinFormTester
{
    static class Program
    {
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

            Application.Run(new LoginForm(inyectionTester, delegateTester));
            //Application.Run(new Form1(inyectionTester, delegateTester));
        }

        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IInyectionTester, InyectionTester>();
                    services.AddSingleton<IDelegateTester, DelegateTester>();
                    //services.AddSignalR();
                });
    }
}