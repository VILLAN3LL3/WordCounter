using System.Collections.Generic;

namespace WordCounter
{
    public class Interactor
    {
        public int CountWords(string text)
        {
            var wordSplitter = new WordSplitter();
            ICollection<string> words = wordSplitter.SplitWords(text);
            return wordSplitter.CountWords(words);
        }
    }
}
