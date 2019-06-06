using System.Threading.Tasks;

namespace PersonalSite.Services
{
    public interface IConfigurationService
    {
        Task<Configuration> GetConfigurationAsync();
    }
}
