using System.Collections.Generic;
using System.Linq;

using TFIDF.keras;

namespace TFIDF
{
    public partial class TFIDFCalc
    {
        public class WordStrategy : IEncodingStrategy
        {
            private readonly Tokenizer _tokenizer;

            public WordStrategy(Tokenizer tokenizer)
            {
                _tokenizer = tokenizer;
            }

            public IEnumerable<string> GetWords(string document)
            {
                return document.Split(_tokenizer.Config.Split.Select(x => x).ToArray()).Select(x => x.ToLowerInvariant());
            }
        }
    }
}
