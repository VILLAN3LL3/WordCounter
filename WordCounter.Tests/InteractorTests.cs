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
                yield return new TestCaseData("Mary has a little lamb.", 4);
                yield return new TestCaseData("Mary has an hour left.", 5);
                yield return new TestCaseData("", 0);
                yield return new TestCaseData("Verstörend", 2);
                yield return new TestCaseData("Take Off Your Pants And Jacket", 5);
            }
        }

        [Test]
        [TestCaseSource(nameof(s_countWordsTestData))]
        public void Should_Count_Words_Of_Supplied_Text(string text, int expectedCount)
        {
            // Arrange
            Interactor interactor = CreateInteractor();

            // Act
            int result = interactor.CountWords(
                text);

            // Assert
            result.Should().Be(expectedCount);
        }
    }
}
