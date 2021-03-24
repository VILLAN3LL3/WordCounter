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

        public void PrintResultToConsole(WordCountResult wordCountResult) =>
            Console.WriteLine($"Number of words: {wordCountResult.NumberOfWords}, unique: {wordCountResult.NumberOfUniqueWords}; average word legnth: {wordCountResult.AverageWordLength} characters");

        public void WaitForInput() => Console.ReadLine();
    }
}
