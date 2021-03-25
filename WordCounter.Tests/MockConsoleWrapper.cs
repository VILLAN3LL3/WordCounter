using System;
using System.Text;

namespace WordCounter.Tests
{
    internal class MockConsoleWrapper : IConsole
    {
        public StringBuilder MockConsole { get; } = new StringBuilder();

        public string ReadLine() => throw new NotImplementedException();
        public void Write(string message) => MockConsole.Append(message);
        public void WriteLine(string message) => MockConsole.AppendLine(message);
    }
}
