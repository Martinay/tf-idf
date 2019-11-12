using System.Collections.Generic;
using System.Linq;

namespace TFIDF
{
    public partial class TFIDFCalc
    {
        public class CharacterStrategy : IEncodingStrategy
        {
            public IEnumerable<string> GetWords(string document)
            {
                return document.Select(x => x.ToString().ToLowerInvariant());
            }
        }
    }
}
