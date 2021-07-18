using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace ConvertYamlToSql
{
    class Program
    {
        private static string GetValue(string[] lines, ref int index)
        {
            var line = lines[index];
            index += 1;
            var i = line.IndexOf(": ", StringComparison.InvariantCulture);
            line = line.Substring(i + 2).Trim();
            return line;
        }

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Courts.yml");

            var sb = new StringBuilder();

            var index = 0;
            while (index < lines.Length)
            {
                var id = GetValue(lines, ref index);
                var name = GetValue(lines, ref index);
                var level = GetValue(lines, ref index);
                sb.AppendLine();
                sb.AppendLine("GO");
                sb.AppendLine($"INSERT INTO [dbo].[Courts] ([id], [name], [level]) VALUES ({id}, N'{name}', N'{level}');");
            }

            File.WriteAllText("Courts.sql", sb.ToString());
        }
    }
}
