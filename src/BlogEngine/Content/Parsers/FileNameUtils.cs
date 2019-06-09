using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace BlogEngine.Content.Parsers
{
    public static class FileNameUtils
    {
        public static (DateTime date, string fileName) ExtractParts(string input)
        {
            var parts = input.Split(new char[] { '-' }, 4);
            string date = MakeDatePart(parts);
            string fileName = parts.Skip(3).Single();
            return (DateTime.Parse(date), fileName);
        }

        public static string ConvertFileNameToUrl(string input)
        {
            input = input.Replace(".md", "");

            var parts = input.Split(new char[] { '-' }, 4);
            return $"{MakeDatePart(parts)}/{parts.Skip(3).Single()}";
        }

        private static string MakeDatePart(string[] parts)
        {
            return $"{parts[0]}/{parts[1].ToString().PadLeft(2, '0')}/{parts[2].ToString().PadLeft(2, '0')}";
        }
    }
}
