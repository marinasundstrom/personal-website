using System.Threading.Tasks;

namespace PersonalSite.Services
{
    public interface IConfigurationLoader
    {
        Task<Configuration> LoadConfigurationAsync();
    }
}