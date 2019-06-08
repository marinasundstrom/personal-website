using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace BlogEngine.Configuration
{
    class ConfigurationImpl : IConfiguration
    {
        private readonly JObject obj;

        public ConfigurationImpl(JObject obj)
        {
            this.obj = obj;
        }

        public T GetValue<T>(string key) => obj.Value<T>(key);

        public IConfiguration GetSection(string key)
        {
            var sectionJsonObj = obj[key];
            return new ConfigurationImpl((JObject)sectionJsonObj);
        }
    }
}
