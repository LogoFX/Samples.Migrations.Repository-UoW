using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YamlDotNet.Serialization;

namespace YamlToNSwag
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    internal class Program
    {
        private static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: YamlToNSwag <yaml file> <nswag file>");
                return -1;
            }

            var yamlFileName = Path.GetFullPath(args[0]);
            var nswagFileName = Path.GetFullPath(args[1]);

            Console.WriteLine($"Input file: '{yamlFileName}'.");
            Console.WriteLine($"Output file: '{nswagFileName}'.");

            using var yamlStr = File.OpenText(yamlFileName);
            var deserializer = new Deserializer();
            var yamlObject = deserializer.Deserialize(yamlStr);

            var jsonStr = JsonConvert.SerializeObject(yamlObject, Formatting.Indented);

            var nswagStr = File.ReadAllText(nswagFileName);
            var nswagObj = (JObject) JsonConvert.DeserializeObject(nswagStr);
            // ReSharper disable PossibleNullReferenceException
            nswagObj["documentGenerator"]["fromDocument"]["json"] = jsonStr;

            nswagStr = JsonConvert.SerializeObject(nswagObj, Formatting.Indented);
            File.WriteAllText(nswagFileName, nswagStr);

            return 0;
        }
    }
}
