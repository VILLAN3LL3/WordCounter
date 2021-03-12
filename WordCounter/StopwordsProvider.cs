using System.Collections.Generic;
using System.IO;

namespace WordCounter
{
    public class StopwordsProvider
    {
        public ICollection<string> GetStopWords() => File.ReadAllLines("stopwords.txt");
    }
}
