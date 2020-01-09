using System;
using System.IO;
using Newtonsoft.Json;

namespace DemoAutomation
{
    public class Config
    {
        private static readonly string PathToConfig =
            File.ReadAllText($@"{AppDomain.CurrentDomain.BaseDirectory}../../../config.json");

        public string BaseUrl { get; set; }

        public string Browser { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public static Config CurrentConfig => JsonConvert.DeserializeObject<Config>(PathToConfig);
    }
}