using System;

namespace WordCounter
{
    public class ConsoleWrapper : IConsole
    {
        public string ReadLine() => Console.ReadLine();
        public void Write(string message) => Console.Write(message);
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}
