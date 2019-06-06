using Microsoft.JSInterop;
using System.Net.Http;
using System.Threading.Tasks;

namespace PersonalSite.Services
{
    public sealed class ConfigurationLoader : IConfigurationLoader
    {
        private const string ConfigFileUri = "config.json";

        private readonly HttpClient httpClient;

        public ConfigurationLoader(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Configuration> LoadConfigurationAsync()
        {
            string configStr = await httpClient.GetStringAsync(ConfigFileUri);
            return Json.Deserialize<Configuration>(configStr);
        }
    }

}
