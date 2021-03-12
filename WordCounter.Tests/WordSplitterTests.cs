using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace WordCounter.Tests
{
    [TestFixture]
    public class WordSplitterTests
    {
        private WordSplitter CreateWordSplitter() => new WordSplitter();

        private static IEnumerable<TestCaseData> s_splitWordsTestData
        {
            get
            {
                yield return new TestCaseData("Mary has a little lamb.", new List<string>() { "Mary", "has", "a", "little", "lamb" });
                yield return new TestCaseData("", new List<string>());
                yield return new TestCaseData("Verstörend", new List<string>() { "Verst", "rend" });
            }
        }

        [Test]
        [TestCaseSource(nameof(s_splitWordsTestData))]
        public void SplitWords_StateUnderTest_ExpectedBehavior(string text, IList<string> expectedResult)
        {
            // Arrange
            WordSplitter wordSplitter = CreateWordSplitter();

            // Act
            IList<string> result = wordSplitter.SplitWords(
                text);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        private static IEnumerable<TestCaseData> s_countWordsTestData
        {
            get
            {
                yield return new TestCaseData(new List<string>() { "Mary", "has", "a", "little", "lamb" }, 5);
                yield return new TestCaseData(new List<string>(), 0);
            }
        }

        [Test]
        [TestCaseSource(nameof(s_countWordsTestData))]
        public void CountWords_StateUnderTest_ExpectedBehavior(IList<string> stringList, int expectedCount)
        {
            // Arrange
            WordSplitter wordSplitter = CreateWordSplitter();

            // Act
            int result = wordSplitter.CountWords(
                stringList);

            // Assert
            result.Should().Be(expectedCount);
        }
    }
}
