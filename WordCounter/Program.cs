namespace WordCounter
{
    internal static class Program
    {
        private static readonly ConsoleUi _ui = new();
        private static readonly Interactor _interactor = new();
        private static readonly FileLoader _fileLoader = new();

        internal static void Main(string[] args) => _fileLoader.GetFilename(args,
            (fileName) =>
        {
            string text = _fileLoader.ReadTextFromFile(fileName);
            WordCountResult wordCountResult = _interactor.CountWords(text);
            _ui.PrintResultToConsole(wordCountResult);
            _ui.WaitForInput();
        }
        , () =>
      {
          string text;
          while (true)
          {
              text = _ui.GetTextFromConsole();
              WordCountResult wordCountResult = _interactor.CountWords(text);
              _ui.PrintResultToConsole(wordCountResult);
          }
      });
    }
}
