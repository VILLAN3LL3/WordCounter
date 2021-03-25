namespace WordCounter
{
    internal static class Program
    {
        private static readonly ConsoleUi _ui = new(new ConsoleWrapper());
        private static readonly Interactor _interactor = new();
        private static readonly FileLoader _fileLoader = new();
        private static readonly ArgsHandler _argHandler = new();

        internal static void Main(string[] args)
        {
            CommandLineArgument commandLineArg = _argHandler.ReadArgs(args);

            if (!string.IsNullOrWhiteSpace(commandLineArg.FilePath))
            {
                string text = _fileLoader.ReadTextFromFile(commandLineArg.FilePath);
                WordCountResult wordCountResult = _interactor.CountWords(text, _fileLoader.ReadLinesFromFile(commandLineArg.DictionaryPath));
                _ui.PrintResultToConsole(wordCountResult, commandLineArg.IsIndexOptionSet);
                _ui.WaitForInput();
            }
            else
            {
                string text;
                while (true)
                {
                    text = _ui.GetTextFromConsole();
                    WordCountResult wordCountResult = _interactor.CountWords(text, _fileLoader.ReadLinesFromFile(commandLineArg.DictionaryPath));
                    _ui.PrintResultToConsole(wordCountResult, commandLineArg.IsIndexOptionSet);
                }
            }
        }
    }
}
