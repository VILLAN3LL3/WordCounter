using System;
using System.IO;

namespace WordCounter
{
    public class FileLoader
    {
        public void GetFilename(string[] args, Action<string> onFilenameFound, Action onNoFilenameFound)
        {
            if (args.Length > 0)
            {
                onFilenameFound(args[0]);
                return;
            }
            onNoFilenameFound();
        }

        public string ReadTextFromFile(string fileName) => File.ReadAllText(fileName);
    }
}
