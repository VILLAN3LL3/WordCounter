namespace WordCounter
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            var ui = new ConsoleUi();
            var interactor = new Interactor();

            string text;
            while (true)
            {
                text = ui.GetTextFromConsole();
                int wordCount = interactor.CountWords(text);
                ui.PrintResultToConsole(text, wordCount);
            }
        }
    }
}
