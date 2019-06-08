using System.Collections.Generic;

namespace BlogEngine.Configuration
{
    public interface IConfiguration
    {
        IConfiguration GetSection(string key);

        T GetValue<T>(string key);
    }
}
