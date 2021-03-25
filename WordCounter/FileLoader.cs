using System;
using System.IO;

namespace WordCounter
{
    public class FileLoader
    {
        public void GetFilename(string filePath, Action<string> onFilenameFound, Action onNoFilenameFound)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                onNoFilenameFound();
                return;
            }
            onFilenameFound(filePath);
        }

        public string ReadTextFromFile(string fileName) => File.ReadAllText(fileName);
    }
}
