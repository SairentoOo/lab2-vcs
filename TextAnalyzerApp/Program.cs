using System;
using System.Windows.Forms;
using Serilog;

namespace Laba1_PO
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("logs/app.log",
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Приложение запущено");

            try
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new MainForm1());
            }
            finally
            {
                Log.Information("Приложение завершено");
                Log.CloseAndFlush();
            }
        }
    }
}