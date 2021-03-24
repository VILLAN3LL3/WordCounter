using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace WordCounter.Tests
{
    [TestFixture]
    public class WordCountTests
    {
        private WordCount CreateWordCount() => new WordCount();

        private static IEnumerable<TestCaseData> s_splitWordsTestData
        {
            get
            {
                yield return new TestCaseData("Mary has a little lamb.", new List<string>() { "Mary", "has", "a", "little", "lamb" });
                yield return new TestCaseData("", new List<string>());
                yield return new TestCaseData("Verstörend", new List<string>() { "Verst", "rend" });
                yield return new TestCaseData("Humpty-Dumpty sat on a wall. Humpty-Dumpty had a great fall.", new List<string>() { "Humpty-Dumpty", "sat", "on", "a", "wall", "Humpty-Dumpty", "had", "a", "great", "fall" });
            }
        }

        [Test]
        [TestCaseSource(nameof(s_splitWordsTestData))]
        public void Should_Split_Text_Into_Words(string text, IList<string> expectedResult)
        {
            // Arrange
            WordCount wordSplitter = CreateWordCount();

            // Act
            ICollection<string> result = wordSplitter.SplitWords(
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
        public void Should_Count_Words_Of_Supplied_Collection(ICollection<string> stringList, int expectedCount)
        {
            // Arrange
            WordCount wordCount = CreateWordCount();

            // Act
            int result = wordCount.CountWords(
                stringList);

            // Assert
            result.Should().Be(expectedCount);
        }

        private static IEnumerable<TestCaseData> s_filterWordsTestData
        {
            get
            {
                yield return new TestCaseData(new List<string>() { "Mary", "has", "a", "little", "lamb" }, new List<string>(), new List<string>() { "Mary", "has", "a", "little", "lamb" });
                yield return new TestCaseData(new List<string>() { "Mary", "has", "a", "little", "lamb" }, new List<string>() { "a" }, new List<string>() { "Mary", "has", "little", "lamb" });
                yield return new TestCaseData(new List<string>() { "Mary", "has", "a", "little", "lamb" }, new List<string>() { "horse" }, new List<string>() { "Mary", "has", "a", "little", "lamb" });
                yield return new TestCaseData(new List<string>() { "Mary", "has", "A", "little", "lamb" }, new List<string>() { "a" }, new List<string>() { "Mary", "has", "little", "lamb" });
            }
        }

        [Test]
        [TestCaseSource(nameof(s_filterWordsTestData))]
        public void Should_Filter_WordList_With_Supplied_Stopwords(ICollection<string> words, ICollection<string> stopwords, ICollection<string> expectedResult)
        {
            // Arrange
            WordCount wordCount = CreateWordCount();

            // Act
            ICollection<string> result = wordCount.Filter(words, stopwords);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        private static IEnumerable<TestCaseData> s_countUniqueWordsTestData
        {
            get
            {
                yield return new TestCaseData(new List<string>() { "Mary", "has", "a", "little", "lamb" }, 5);
                yield return new TestCaseData(new List<string>(), 0);
                yield return new TestCaseData(new List<string>() { "Humpty", "Dumpty", "sat", "on", "a", "wall", "Humpty", "Dumpty", "had", "a", "great", "fall" }, 9);
                yield return new TestCaseData(new List<string>() { "Humpty", "Dumpty", "sat", "on", "A", "wall", "HUMPTY", "dumpty", "had", "a", "great", "fall" }, 9);
            }
        }

        [Test]
        [TestCaseSource(nameof(s_countUniqueWordsTestData))]
        public void Should_Count_Unique_Words_Of_Supplied_Collection(ICollection<string> stringList, int expectedCount)
        {
            // Arrange
            WordCount wordCount = CreateWordCount();

            // Act
            int result = wordCount.CountUniqueWords(
                stringList);

            // Assert
            result.Should().Be(expectedCount);
        }

        private static IEnumerable<TestCaseData> s_countAverageWordCountTestData
        {
            get
            {
                yield return new TestCaseData(new List<string>() { "Mary", "has", "a", "little", "lamb" }, 3.60);
                yield return new TestCaseData(new List<string>(), 0.00);
                yield return new TestCaseData(new List<string>() { "Humpty", "Dumpty", "sat", "on", "a", "wall", "Humpty", "Dumpty", "had", "a", "great", "fall" }, 3.92);
            }
        }

        [Test]
        [TestCaseSource(nameof(s_countAverageWordCountTestData))]
        public void Should_Calcuate_Average_Word_Length_Of_Supplied_Collection(ICollection<string> stringList, double expectedCount)
        {
            // Arrange
            WordCount wordCount = CreateWordCount();

            // Act
            double result = wordCount.CalculateAverageWordLength(
                stringList);

            // Assert
            result.Should().Be(expectedCount);
        }
    }
}
