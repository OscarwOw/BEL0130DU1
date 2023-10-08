using System;
using System.Text;


namespace BEL0130DU1
{
    public sealed class FileHandler
    {
        private static readonly Lazy<FileHandler> lazyInstance = new Lazy<FileHandler>(() => new FileHandler());
        public static FileHandler Instance => lazyInstance.Value;
        private FileHandler(){}

        public string? ReadAllText(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
                return null;
            }
        }
        public IEnumerable<string> GetCountries(string csv)
        {
            return GetLines(csv).Skip(1);
        }
        private IEnumerable<string> GetLines(string csv)
        {
            return csv.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        }
        private IEnumerable<string> SplitToCells(string line)
        {
            return line.Split(";");
        }
        private void PrintListOfStrings(IEnumerable<string> list)
        {
            foreach (string s in list) {
                Console.Write($" {s} ");
            }
        }
        public void PrintFormatedLines(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                PrintListOfStrings(SplitToCells(line));
                Console.WriteLine("");
            }
        }


    }
}
