using System.Globalization;
using System.Linq;

namespace WordCounter
{
    public class ConsoleUi
    {
        private IConsole _console;

        public ConsoleUi(IConsole console)
        {
            _console = console;
        }

        public IConsole GetConsole() => _console;

        public string GetTextFromConsole()
        {
            _console.WriteLine("Enter the text");
            return _console.ReadLine();
        }

        public void PrintResultToConsole(WordCountResult wordCountResult, bool isIndexOptionSet)
        {
            PrintSummary(wordCountResult);

            if (isIndexOptionSet)
            {
                PrintIndex(wordCountResult);
            }
        }

        private void PrintSummary(WordCountResult wordCountResult) =>
                    _console.WriteLine($"Number of words: {wordCountResult.NumberOfWords}, " +
                        $"unique: {wordCountResult.NumberOfUniqueWords}; " +
                        $"average word length: {string.Format(CultureInfo.InvariantCulture, "{0:0.00}", wordCountResult.AverageWordLength)} characters");

        private void PrintIndex(WordCountResult wordCountResult)
        {
            _console.WriteLine($"Index (unknown: {wordCountResult.Index.Where(i => i.IsUnknown).Count()}):");
            foreach (IndexResult indexItem in wordCountResult.Index)
            {
                _console.WriteLine(indexItem.ToString());
            }
        }

        public void WaitForInput() => _console.ReadLine();
    }
}
