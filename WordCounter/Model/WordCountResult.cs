using System.Collections.Generic;

namespace WordCounter
{
    public record WordCountResult(int NumberOfWords, int NumberOfUniqueWords, double AverageWordLength, ICollection<string> Index);
}
