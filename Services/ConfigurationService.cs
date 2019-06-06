using System.Threading.Tasks;

namespace PersonalSite.Services
{
    public sealed class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationLoader configurationLoader;
        private Configuration currentConfiguration;

        public ConfigurationService(IConfigurationLoader configurationLoader)
        {
            this.configurationLoader = configurationLoader;
        }

        public async Task<Configuration> GetConfigurationAsync()
        {
            if (currentConfiguration == null)
            {
                currentConfiguration = await configurationLoader.LoadConfigurationAsync();
            }
            return currentConfiguration;
        }
    }
}
