using System.Collections.Generic;

namespace TFIDF
{
    public partial class TFIDFCalc
    {
        private interface IEncodingStrategy
        {
            IEnumerable<string> GetWords(string document);
        }
    }
}
