using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace WordCounter.Tests
{
    [TestFixture]
    public class ConsoleUiTests
    {
        private IConsole _subConsole;
        private IConsole _mockConsole;

        [SetUp]
        public void SetUp()
        {
            _subConsole = Substitute.For<IConsole>();
            _mockConsole = new MockConsoleWrapper();
        }

        private ConsoleUi CreateConsoleUi() => new ConsoleUi(_subConsole);

        private ConsoleUi CreateMockConsoleUi() => new ConsoleUi(_mockConsole);

        [Test]
        public void Should_Get_Text_From_Console()
        {
            // Arrange
            ConsoleUi consoleUi = CreateConsoleUi();
            _subConsole.ReadLine().Returns("My text");

            // Act
            string result = consoleUi.GetTextFromConsole();

            // Assert
            result.Should().Be("My text");
        }

        private static IEnumerable<TestCaseData> s_printResultTestData
        {
            get
            {
                yield return new TestCaseData(
                    new WordCountResult(4, 4, 4.25, new List<IndexResult>() {
                        new IndexResult("has", true),
                        new IndexResult("lamb", true),
                        new IndexResult("little", true),
                        new IndexResult("Mary", true) }),
                    false,
                    "Number of words: 4, unique: 4; average word length: 4.25 characters\r\n");
                yield return new TestCaseData(
                    new WordCountResult(5, 4, 4.20, new List<IndexResult>() {
                        new IndexResult("has", false),
                        new IndexResult("lamb", true),
                        new IndexResult("little", false),
                        new IndexResult("Mary", true),
                        new IndexResult("Mary", true) }),
                    true,
                    "Number of words: 5, unique: 4; average word length: 4.20 characters\r\nIndex (unknown: 3):\r\nhas\r\nlamb*\r\nlittle\r\nMary*\r\nMary*\r\n");
                yield return new TestCaseData(
                    new WordCountResult(0, 0, 0.00, new List<IndexResult>()),
                    true,
                    "Number of words: 0, unique: 0; average word length: 0.00 characters\r\nIndex (unknown: 0):\r\n");
            }
        }

        [Test]
        [TestCaseSource(nameof(s_printResultTestData))]
        public void Should_Print_Result_To_Console(WordCountResult wordCountResult, bool isIndexOptionSet, string expectedResult)
        {
            // Arrange
            ConsoleUi consoleUi = CreateMockConsoleUi();

            // Act
            consoleUi.PrintResultToConsole(
                wordCountResult,
                isIndexOptionSet);

            // Assert
            var consoleWrapper = consoleUi.GetConsole() as MockConsoleWrapper;
            consoleWrapper.MockConsole.ToString().Should().Be(expectedResult);
        }

        [Test]
        public void Should_Wait_For_Input()
        {
            // Arrange
            ConsoleUi consoleUi = CreateConsoleUi();

            // Act
            consoleUi.WaitForInput();

            // Assert
            _subConsole.Received().ReadLine();
        }
    }
}
