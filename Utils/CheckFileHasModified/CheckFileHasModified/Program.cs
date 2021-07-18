using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CheckFileHasModified
{
    internal static class Program
    {
        private const string HashStreamName = "ad_hash";

        private const int IncorrectUsageCode = 1;
        private const int SuccessfullyCode = 0;
        private const int FileChangedCode = -1;

        private static async Task<int> Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: CheckFileHasModified <filename> [-s]");
                return IncorrectUsageCode;
            }

            var doSet = false;
            if (args.Length > 1)
            {
                var options = args[1];
                if (options != "-s")
                {
                    Console.WriteLine($"Unknown options: {options}");
                    Console.WriteLine("Usage: CheckFileHasModified <filename> [-s]");
                    return IncorrectUsageCode;
                }

                doSet = true;
            }

            var fileName = Path.GetFullPath(args[0]);
            Console.WriteLine($"Checking '{fileName}'...");

            var additionalStreamName = $"{fileName}:{HashStreamName}";
            if (doSet)
            {
                var currentHash = await GetSha1Hash(fileName);
                await File.WriteAllTextAsync(additionalStreamName, currentHash);
            }
            else
            {
                if (!File.Exists(additionalStreamName))
                {
                    return FileChangedCode;
                }

                var storedHash = await File.ReadAllTextAsync(additionalStreamName);
                var currentHash = await GetSha1Hash(fileName);

                if (storedHash != currentHash)
                {
                    return FileChangedCode;
                }
            }

            return SuccessfullyCode;
        }

        private static async Task<string> GetSha1Hash(string pathName)
        {
            var hasher = new SHA1CryptoServiceProvider();

            byte[] bytes;
            await using (var fileStream = File.Open(pathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                bytes = await hasher.ComputeHashAsync(fileStream);
            }

            var strHashData = BitConverter.ToString(bytes);
            strHashData = strHashData.Replace("-", "");
            return strHashData;
        }
    }
}
