using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCounter
{
    public class WordSplitter
    {
        private readonly Regex _pattern = new Regex(@"[A-Za-z]+");

        public IList<string> SplitWords(string text) => _pattern.Matches(text).Select(m => m.Value).ToList();

        public int CountWords(IList<string> matchCollection) => matchCollection.Count;
    }
}
