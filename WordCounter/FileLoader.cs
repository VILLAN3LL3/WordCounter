using System;
using System.IO;

namespace WordCounter
{
    public class FileLoader
    {
        public string ReadTextFromFile(string fileName) => File.ReadAllText(fileName);

        public string[] ReadLinesFromFile(string fileName) => string.IsNullOrWhiteSpace(fileName) ? Array.Empty<string>() : File.ReadAllLines(fileName);
    }
}
