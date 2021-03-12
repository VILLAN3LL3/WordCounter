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

        public void PrintResultToConsole(string text, int wordCount) => Console.WriteLine($"The text '{text}' contains {wordCount} words");
    }
}
