using System.Collections.Generic;
using System.IO;

namespace WordCounter
{
    public class StopwordsProvider
    {
        public ICollection<string> GetStopWords()
        {
            return File.ReadAllLines("stopwords.txt");
        }
    }
}
