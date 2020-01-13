using System;
using System.IO;
using DemoAutomation.Utils;
using NUnit.Framework;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Telegram;

namespace DemoAutomation
{
    [SetUpFixture]
    public class SetUpFixture
    {
        private const string LogFolder = "Logs";
        private const string LogTemplate = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] [{ProcessId}] [{EnvironmentUserName}] {Message:lj}{NewLine}{Exception}";
        
        [OneTimeSetUp]
        [LogMethod]
        public void OneTimeSetUp()
        {
            CleanLogDirectory();
            var currentDateTime = DateTime.Now.ToString("dd-MM-yyyy-(hh-mm-ss)");
            var pathToLog = Path.Combine(TestContext.CurrentContext.WorkDirectory, $"{LogFolder}", $"{currentDateTime}",
                "debugLog.txt");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(pathToLog, Serilog.Events.LogEventLevel.Debug, outputTemplate: LogTemplate)
                .WriteTo.Telegram("882242070:AAEOD8v3WLhViQsFR5J3U8mOYmIzm-W2Tu4", "317113860", restrictedToMinimumLevel: LogEventLevel.Error)
                .Enrich.WithProcessId()
                .Enrich.WithEnvironmentUserName()
                .CreateLogger();
        }

        [OneTimeTearDown]
        [LogMethod]
        public void OneTimeTearDown()
        {
            Log.CloseAndFlush();
        }

        private void CleanLogDirectory()
        {
            var pathToDirectory = new DirectoryInfo(Path.Combine(TestContext.CurrentContext.WorkDirectory, $"{LogFolder}"));
            foreach (var directory in pathToDirectory.GetDirectories())
            {
                directory.Delete(true);
            }
        }
    }
}