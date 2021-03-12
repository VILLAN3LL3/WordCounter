using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace WordCounter.Tests
{
    [TestFixture]
    public class FileLoaderTests
    {
        private FileLoader CreateFileLoader() => new FileLoader();

        [Test]
        public void Should_Call_onFilenameFound_Action_If_Args_Contain_Filename()
        {
            // Arrange
            FileLoader fileLoader = CreateFileLoader();
            string[] args = new[] { "meingedicht.txt" };
            Action<string> onFilenameFound = Substitute.For<Action<string>>();
            Action onNoFilenameFound = Substitute.For<Action>();

            // Act
            fileLoader.GetFilename(
                args,
                onFilenameFound,
                onNoFilenameFound);

            // Assert
            onFilenameFound.Received(1).Invoke(Arg.Any<string>());
            onNoFilenameFound.Received(0).Invoke();
        }

        [Test]
        public void Should_Call_onNoFilenameFound_Action_If_Args_Does_Not_Contain_Filename()
        {
            // Arrange
            FileLoader fileLoader = CreateFileLoader();
            string[] args = Array.Empty<string>();
            Action<string> onFilenameFound = Substitute.For<Action<string>>();
            Action onNoFilenameFound = Substitute.For<Action>();

            // Act
            fileLoader.GetFilename(
                args,
                onFilenameFound,
                onNoFilenameFound);

            // Assert
            onFilenameFound.Received(0).Invoke(Arg.Any<string>());
            onNoFilenameFound.Received(1).Invoke();
        }

        [Test]
        public void Should_Read_Text_From_File()
        {
            // Arrange
            FileLoader fileLoader = CreateFileLoader();
            string expectedResult = "The Elephant " +
                "Anonymous " +
                "An elephant slept in his bunk, " +
                "And in slumber his chest rose and sunk. " +
                "But he snored — how he snored! " +
                "All the other beasts roared, " +
                "So his wife tied a knot in his trunk.";
            string fileName = "meingedicht.txt";

            // Act
            string result = fileLoader.ReadTextFromFile(
                fileName);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
