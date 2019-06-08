using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlogEngine.Configuration.Parsers;
using Newtonsoft.Json.Linq;

namespace BlogEngine.Configuration
{
    public sealed class ConfigurationManager : IConfigurationManager
    {
        private const string ConfigFileUri = "config.json";

        private readonly HttpClient httpClient;
        private readonly ConfigurationParser parser;

        public ConfigurationManager(HttpClient httpClient, ConfigurationParser parser) 
        {
            this.httpClient = httpClient;
            this.parser = parser;
        }

        public async Task LoadConfigurationAsync()
        {
            if(Configuration == null) 
            {
                string configStr = await httpClient.GetStringAsync(ConfigFileUri);
                Configuration = new ConfigurationImpl(JObject.Parse(configStr));
            }
        }

        public IConfiguration Configuration { get; private set; }
    }
}
