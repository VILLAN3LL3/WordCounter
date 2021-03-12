namespace WordCounter
{
    internal static class Program
    {
        private static readonly ConsoleUi _ui = new();
        private static readonly Interactor _interactor = new();
        private static readonly FileLoader _fileLoader = new();

        internal static void Main(string[] args) => _fileLoader.GetFilename(args, UseFile, UseConsole);

        private static void UseConsole()
        {
            string text;
            while (true)
            {
                text = _ui.GetTextFromConsole();
                int wordCount = _interactor.CountWords(text);
                _ui.PrintResultToConsole(text, wordCount);
            }
        }

        private static void UseFile(string fileName)
        {
            string text = _fileLoader.ReadTextFromFile(fileName);
            int wordCount = _interactor.CountWords(text);
            _ui.PrintResultToConsole(text, wordCount);
            _ui.WaitForInput();
        }
    }
}
