using System.Collections.Generic;

namespace WordCounter
{
    public class Interactor
    {
        public int CountWords(string text)
        {
            var wordSplitter = new WordCount();
            var stopwordsProvider = new StopwordsProvider();

            ICollection<string> words = wordSplitter.SplitWords(text);
            var stopwords = stopwordsProvider.GetStopWords();
            ICollection<string> filteredWords = wordSplitter.Filter(words, stopwords);
            return wordSplitter.CountWords(filteredWords);
        }
    }
}
