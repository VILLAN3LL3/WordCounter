using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCounter
{
    public class WordCount
    {
        private readonly Regex _pattern = new("[A-Za-z]+");

        public ICollection<string> SplitWords(string text) => _pattern.Matches(text).Select(m => m.Value).ToList();

        public int CountWords(ICollection<string> words) => words.Count;

        public ICollection<string> Filter(ICollection<string> words, ICollection<string> stopWords)
            => words.Where(w => !stopWords.Contains(w, StringComparer.InvariantCultureIgnoreCase)).ToList();

        public int CountUniqueWords(ICollection<string> words) => words.Distinct(StringComparer.InvariantCultureIgnoreCase).Count();
    }
}
