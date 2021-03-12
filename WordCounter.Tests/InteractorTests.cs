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
                yield return new TestCaseData("Mary has a little lamb.", 5);
                yield return new TestCaseData("", 0);
                yield return new TestCaseData("Verstörend", 2);
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
