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

            _console.WriteLine($"Number of words: {wordCountResult.NumberOfWords}, " +
                $"unique: {wordCountResult.NumberOfUniqueWords}; " +
                $"average word length: {string.Format("{0:0.00}", wordCountResult.AverageWordLength)} characters");
            if (isIndexOptionSet)
            {
                _console.WriteLine("Index:");
                foreach (string word in wordCountResult.Index)
                {
                    _console.WriteLine(word);
                }
            }
        }

        public void WaitForInput() => _console.ReadLine();
    }
}
