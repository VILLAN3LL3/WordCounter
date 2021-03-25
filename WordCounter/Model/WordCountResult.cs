using System.Collections.Generic;

namespace WordCounter
{
    public record WordCountResult(int NumberOfWords, int NumberOfUniqueWords, double AverageWordLength, ICollection<IndexResult> Index);

    public record IndexResult(string Word, bool IsUnknown)
    {
        public override string ToString() => $"{Word}{( IsUnknown ? '*' : "" )}";
    }
}
