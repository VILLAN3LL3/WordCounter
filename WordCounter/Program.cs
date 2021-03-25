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
            var commandLineArg = _argHandler.ReadArgs(args);
            _fileLoader.GetFilename(commandLineArg.FilePath,
            (fileName) =>
        {
            string text = _fileLoader.ReadTextFromFile(fileName);
            WordCountResult wordCountResult = _interactor.CountWords(text);
            _ui.PrintResultToConsole(wordCountResult, commandLineArg.IsIndexOptionSet);
            _ui.WaitForInput();
        }
        , () =>
      {
          string text;
          while (true)
          {
              text = _ui.GetTextFromConsole();
              WordCountResult wordCountResult = _interactor.CountWords(text);
              _ui.PrintResultToConsole(wordCountResult, commandLineArg.IsIndexOptionSet);
          }
      });
        }
    }
}
