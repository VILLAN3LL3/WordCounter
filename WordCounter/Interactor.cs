using System.Collections.Generic;

namespace WordCounter
{
    public class Interactor
    {
        public WordCountResult CountWords(string text, ICollection<string> dictionaryWords)
        {
            var wordCount = new WordCount();
            var stopwordsProvider = new StopwordsProvider();

            ICollection<string> words = wordCount.SplitWords(text);
            ICollection<string> stopwords = stopwordsProvider.GetStopWords();
            ICollection<string> filteredWords = wordCount.Filter(words, stopwords);
            ICollection<string> sortedWords = wordCount.Sort(filteredWords);

            return new WordCountResult(
                wordCount.CountWords(filteredWords),
                wordCount.CountUniqueWords(filteredWords),
                wordCount.CalculateAverageWordLength(filteredWords),
                wordCount.CreateIndex(sortedWords, dictionaryWords));
        }
    }
}
