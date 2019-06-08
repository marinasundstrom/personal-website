using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace BlogEngine.Content.Parsers
{
    public class FrontMatterParser
    {
        public FrontMatter Parse(string input)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            return deserializer.Deserialize<FrontMatter>(input);
        }
    }
}
