using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCounter
{
    public class WordCount
    {
        private readonly Regex _pattern = new("[A-Za-z-]+");

        public ICollection<string> SplitWords(string text) => _pattern
            .Matches(text)
            .Select(m => m.Value)
            .ToList();

        public int CountWords(ICollection<string> words) => words.Count;

        public ICollection<string> Filter(ICollection<string> words, ICollection<string> stopWords)
            => words
                .Where(w => !stopWords.Contains(w, StringComparer.InvariantCultureIgnoreCase))
                .OrderBy(word => word)
                .ToList();

        public ICollection<string> Sort(ICollection<string> words)
            => words.OrderBy(word => word).ToList();

        public int CountUniqueWords(ICollection<string> words) => words
            .Distinct(StringComparer.InvariantCultureIgnoreCase)
            .Count();

        internal ICollection<IndexResult> CreateIndex(ICollection<string> sortedWords, ICollection<string> dictionaryWords) => sortedWords
            .Select(word => new IndexResult(word, !dictionaryWords.Contains(word, StringComparer.InvariantCultureIgnoreCase)))
            .ToList();

        public double CalculateAverageWordLength(ICollection<string> words) => words.Count > 0
            ? Math.Round(words.Select(word => word.Length).Average(), 2)
            : 0.00;
    }
}
