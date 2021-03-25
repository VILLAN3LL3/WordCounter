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
                yield return new TestCaseData(Array.Empty<string>(), new CommandLineArgument(string.Empty, false));
                yield return new TestCaseData(new string[] { "meingedicht.txt" }, new CommandLineArgument("meingedicht.txt", false));
                yield return new TestCaseData(new string[] { "meingedicht.txt", "-index" }, new CommandLineArgument("meingedicht.txt", true));
                yield return new TestCaseData(new string[] { "-index", "meingedicht.txt" }, new CommandLineArgument("meingedicht.txt", true));
                yield return new TestCaseData(new string[] { "-index" }, new CommandLineArgument(string.Empty, true));
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
