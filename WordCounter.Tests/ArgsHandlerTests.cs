using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace WordCounter.Tests
{
    [TestFixture]
    public class ArgsHandlerTests
    {


        [SetUp]
        public void SetUp()
        {

        }

        private ArgsHandler CreateArgsHandler() => new ArgsHandler();

        private static IEnumerable<TestCaseData> s_argsTestData
        {
            get
            {
                yield return new TestCaseData(Array.Empty<string>(), new CommandLineArgument(string.Empty, false, string.Empty));
                yield return new TestCaseData(new string[] { "meingedicht.txt" }, new CommandLineArgument("meingedicht.txt", false, string.Empty));
                yield return new TestCaseData(new string[] { "meingedicht.txt", "-index" }, new CommandLineArgument("meingedicht.txt", true, string.Empty));
                yield return new TestCaseData(new string[] { "-index", "meingedicht.txt" }, new CommandLineArgument("meingedicht.txt", true, string.Empty));
                yield return new TestCaseData(new string[] { "-index" }, new CommandLineArgument(string.Empty, true, string.Empty));
                yield return new TestCaseData(new string[] { "-index", "-dictionary=dict.txt" }, new CommandLineArgument(string.Empty, true, "dict.txt"));
                yield return new TestCaseData(new string[] { "meingedicht.txt", "-index", "-dictionary=dict.txt" }, new CommandLineArgument("meingedicht.txt", true, "dict.txt"));
                yield return new TestCaseData(new string[] { "-index", "meingedicht.txt", "-dictionary=dict.txt" }, new CommandLineArgument("meingedicht.txt", true, "dict.txt"));
                yield return new TestCaseData(new string[] { "-index", "-dictionary=dict.txt", "meingedicht.txt" }, new CommandLineArgument("meingedicht.txt", true, "dict.txt"));
                yield return new TestCaseData(new string[] { "-dictionary=dict.txt", "-index", "meingedicht.txt" }, new CommandLineArgument("meingedicht.txt", true, "dict.txt"));
            }
        }

        [Test]
        [TestCaseSource(nameof(s_argsTestData))]
        public void Should_Read_Args(string[] args, CommandLineArgument expectedResult)
        {
            // Arrange
            ArgsHandler argsHandler = CreateArgsHandler();

            // Act
            CommandLineArgument result = argsHandler.ReadArgs(
                args);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
