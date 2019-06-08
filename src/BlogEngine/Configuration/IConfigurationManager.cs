using System.Threading.Tasks;

namespace BlogEngine.Configuration
{
    public interface IConfigurationManager
    {
        Task LoadConfigurationAsync();
        IConfiguration Configuration { get; }
    }
}
