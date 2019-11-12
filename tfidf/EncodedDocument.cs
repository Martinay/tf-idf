namespace TFIDF
{
    public partial class TFIDFCalc
    {
        public class EncodedDocument
        {
            public EncodedDocument(float[] encodedWords)
            {
                EncodedWords = encodedWords;
            }

            public float[] EncodedWords { get; }
        }
    }
}
