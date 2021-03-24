using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace WordCounter.Tests
{
    [TestFixture]
    public class InteractorTests
    {
        private Interactor CreateInteractor() => new Interactor();

        private static IEnumerable<TestCaseData> s_countWordsTestData
        {
            get
            {
                yield return new TestCaseData("Mary has a little lamb.", new WordCountResult(4, 4));
                yield return new TestCaseData("Mary Mary has a little lamb.", new WordCountResult(5, 4));
                yield return new TestCaseData("Mary has an hour left.", new WordCountResult(5, 5));
                yield return new TestCaseData("", new WordCountResult(0, 0));
                yield return new TestCaseData("Verstörend", new WordCountResult(2, 2));
                yield return new TestCaseData("Take Off Your Pants And Jacket", new WordCountResult(5, 5));
                yield return new TestCaseData("Humpty-Dumpty sat on a wall. Humpty-Dumpty had a great fall.", new WordCountResult(7, 6));
            }
        }

        [Test]
        [TestCaseSource(nameof(s_countWordsTestData))]
        public void Should_Count_Words_Of_Supplied_Text(string text, WordCountResult expectedResult)
        {
            // Arrange
            Interactor interactor = CreateInteractor();

            // Act
            WordCountResult result = interactor.CountWords(
                text);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
