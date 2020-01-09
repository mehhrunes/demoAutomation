﻿using System;
using System.IO;
using NUnit.Framework;
using Serilog;

namespace DemoAutomation
{
    [SetUpFixture]
    public class SetUpFixture
    {
        private const string LogFolder = "Logs";
        private const string LogTemplate = "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] [{ProcessId}] [{EnvironmentUserName}] {Message:lj}{NewLine}{Exception}";
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            CleanLogDirectory();
            var currentDateTime = DateTime.Now.ToString("dd-MM-yyyy-(hh-mm-ss)");
            var pathToLog = Path.Combine(TestContext.CurrentContext.WorkDirectory, $"{LogFolder}", $"{currentDateTime}",
                "debugLog.txt");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(pathToLog, Serilog.Events.LogEventLevel.Debug, outputTemplate: LogTemplate)
                .Enrich.WithProcessId()
                .Enrich.WithEnvironmentUserName()
                .CreateLogger();
        }

        [OneTimeTearDown]
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