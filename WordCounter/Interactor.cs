using System.Collections.Generic;

namespace WordCounter
{
    public class Interactor
    {
        public WordCountResult CountWords(string text)
        {
            var wordCount = new WordCount();
            var stopwordsProvider = new StopwordsProvider();

            ICollection<string> words = wordCount.SplitWords(text);
            ICollection<string> stopwords = stopwordsProvider.GetStopWords();
            ICollection<string> filteredWords = wordCount.Filter(words, stopwords);

            return new WordCountResult(
                wordCount.CountWords(filteredWords),
                wordCount.CountUniqueWords(filteredWords),
                wordCount.CalculateAverageWordLength(filteredWords),
                wordCount.Sort(filteredWords));
        }
    }
}
