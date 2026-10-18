using System;
using System.IO;

namespace Laba1_PO
{
    public static class Logger
    {
        public static void Log(string message)
        {
            string logLine = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            File.AppendAllText("app.log", logLine + Environment.NewLine);
            Console.WriteLine(logLine);
        }
    }
}