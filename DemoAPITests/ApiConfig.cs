using Newtonsoft.Json;
using System;
using System.IO;

namespace DemoAPITests
{
    public class ApiConfig
    {
        private static readonly string PathToConfig =
            File.ReadAllText($@"{AppDomain.CurrentDomain.BaseDirectory}../../../apiConfig.json");

        public string BaseUrl { get; set; }

        public static ApiConfig CurrentApiConfig => JsonConvert.DeserializeObject<ApiConfig>(PathToConfig);
    }
}
