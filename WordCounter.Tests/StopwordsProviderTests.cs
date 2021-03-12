using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace WordCounter.Tests
{
    [TestFixture]
    public class StopwordsProviderTests
    {
        private StopwordsProvider CreateProvider() => new StopwordsProvider();

        [Test]
        public void GetStopWords_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            StopwordsProvider provider = CreateProvider();
            var expectedResult = new List<string>() { "a", "the", "on", "off" };

            // Act
            ICollection<string> result = provider.GetStopWords();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
