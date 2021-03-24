using System.Collections.Generic;

namespace WordCounter
{
    public class Interactor
    {
        public WordCountResult CountWords(string text)
        {
            var wordSplitter = new WordCount();
            var stopwordsProvider = new StopwordsProvider();

            ICollection<string> words = wordSplitter.SplitWords(text);
            ICollection<string> stopwords = stopwordsProvider.GetStopWords();
            ICollection<string> filteredWords = wordSplitter.Filter(words, stopwords);

            return new WordCountResult(
                wordSplitter.CountWords(filteredWords),
                wordSplitter.CountUniqueWords(filteredWords),
                wordSplitter.CalculateAverageWordLength(filteredWords));
        }
    }
}
