using Serilog;

namespace TesterProject.BusinessLogic.Utils
{
    public class Logger
    {
        public static class LoggerConfig
        {
            private static readonly Lock _lock = new();
            private static bool _isInitialized = false;

            public static void ConfigureLogger()
            {
                if (_isInitialized) return;

                lock (_lock)
                {
                    if (_isInitialized) return;

                    string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
                    string logPath = Path.Combine(logDirectory, "log.txt");

                    // Crear el directorio si no existe
                    if (!Directory.Exists(logDirectory))
                    {
                        Directory.CreateDirectory(logDirectory);
                    }

                    Log.Logger = new LoggerConfiguration()
                        .WriteTo.File(logPath, rollingInterval: RollingInterval.Day, buffered: true, flushToDiskInterval: TimeSpan.FromSeconds(5))
                        .CreateLogger();

                    _isInitialized = true;
                }
            }
        }
    }
}
