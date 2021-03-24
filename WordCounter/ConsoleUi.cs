using System;

namespace WordCounter
{
    public class ConsoleUi
    {
        public string GetTextFromConsole()
        {
            Console.WriteLine("Enter the text");
            return Console.ReadLine();
        }

        public void PrintResultToConsole(string text, WordCountResult wordCountResult) => Console.WriteLine($"The text '{text}' contains " +
            $"{wordCountResult.NumberOfWords} words and {wordCountResult.NumberOfUniqueWords} unique words.");

        public void WaitForInput() => Console.ReadLine();
    }
}
