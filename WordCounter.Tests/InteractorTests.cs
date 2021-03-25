using System;
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
                yield return new TestCaseData(
                    "Mary has a little lamb.",
                    new string[] { "big", "small", "little", "cat", "dog", "have", "has", "had" },
                    new WordCountResult(
                        4,
                        4,
                        4.25,
                        new List<IndexResult>() {
                            new IndexResult("has", false),
                            new IndexResult("lamb", true),
                            new IndexResult("little", false),
                            new IndexResult("Mary", true) }));
                yield return new TestCaseData(
                    "Mary Mary has a little lamb.",
                    new string[] { "big", "small", "little", "cat", "dog", "have", "has", "had" },
                    new WordCountResult(
                        5,
                        4,
                        4.20,
                        new List<IndexResult>() {
                            new IndexResult("has", false),
                            new IndexResult("lamb", true),
                            new IndexResult("little", false),
                            new IndexResult("Mary", true),
                            new IndexResult("Mary", true) }));
                yield return new TestCaseData(
                    "Mary has an hour left.",
                    new string[] { "big", "small", "little", "cat", "dog", "have", "has", "had" },
                    new WordCountResult(
                        5,
                        5,
                        3.40,
                        new List<IndexResult>() {
                            new IndexResult("an", true),
                            new IndexResult("has", false),
                            new IndexResult("hour", true),
                            new IndexResult("left", true),
                            new IndexResult("Mary", true) }));
                yield return new TestCaseData(
                    "",
                    new string[] { "big", "small", "little", "cat", "dog", "have", "has", "had" },
                    new WordCountResult(
                        0,
                        0,
                        0.00,
                        new List<IndexResult>()));
                yield return new TestCaseData(
                    "Verstörend",
                    new string[] { "big", "small", "little", "cat", "dog", "have", "has", "had" },
                    new WordCountResult(
                        2,
                        2,
                        4.50,
                        new List<IndexResult>() {
                            new IndexResult("rend", true),
                            new IndexResult("Verst", true) }));
                yield return new TestCaseData(
                    "Take Off Your Pants And Jacket",
                    new string[] { "big", "small", "little", "cat", "dog", "have", "pants", "jacket" },
                    new WordCountResult(
                        5,
                        5,
                        4.40,
                        new List<IndexResult>() {
                            new IndexResult("And", true),
                            new IndexResult("Jacket", false),
                            new IndexResult("Pants", false),
                            new IndexResult("Take", true),
                            new IndexResult("Your", true) }));
                yield return new TestCaseData(
                    "Humpty-Dumpty sat on a wall. Humpty-Dumpty had a great fall.",
                    new string[] { "big", "small", "little", "cat", "dog", "have", "has", "had" },
                    new WordCountResult(
                        7,
                        6,
                        6.43,
                        new List<IndexResult>() {
                            new IndexResult("fall", true),
                            new IndexResult("great", true),
                            new IndexResult("had", false),
                            new IndexResult("Humpty-Dumpty", true),
                            new IndexResult("Humpty-Dumpty", true),
                            new IndexResult("sat", true),
                            new IndexResult("wall", true) }));
                yield return new TestCaseData(
                    "Mary has a little lamb.",
                    Array.Empty<string>(),
                    new WordCountResult(
                        4,
                        4,
                        4.25,
                        new List<IndexResult>() {
                            new IndexResult("has", true),
                            new IndexResult("lamb", true),
                            new IndexResult("little", true),
                            new IndexResult("Mary", true) }));
            }
        }

        [Test]
        [TestCaseSource(nameof(s_countWordsTestData))]
        public void Should_Count_Words_Of_Supplied_Text(string text, string[] dictionaryWords, WordCountResult expectedResult)
        {
            // Arrange
            Interactor interactor = CreateInteractor();

            // Act
            WordCountResult result = interactor.CountWords(
                text,
                dictionaryWords);

            // Assert
            result.NumberOfWords.Should().Be(expectedResult.NumberOfWords);
            result.AverageWordLength.Should().Be(expectedResult.AverageWordLength);
            result.NumberOfUniqueWords.Should().Be(expectedResult.NumberOfUniqueWords);
            result.Index.Should().BeEquivalentTo(expectedResult.Index, config => config.WithStrictOrdering());
        }
    }
}
