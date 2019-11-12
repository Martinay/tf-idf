using System;
using System.Collections.Generic;
using System.Linq;

using TFIDF.keras;

namespace TFIDF
{
    public partial class TFIDFCalc
    {
        private readonly Tokenizer _tokenizer;

        public TFIDFCalc(Tokenizer tokenizer)
        {
            _tokenizer = tokenizer;
        }

        public List<EncodedDocument> TextsToMatrix(IList<string> documents)
        {
            IEncodingStrategy splitStrategy;
            if (_tokenizer.Config.CharLevel)
                splitStrategy = new CharacterStrategy();
            else
                splitStrategy = new WordStrategy(_tokenizer);

            var transformedDocuments = documents
                .AsParallel()
                .Select(x => splitStrategy.GetWords(x).ToList())
                .Select(TransformDocument)
                .ToList();
            
            return transformedDocuments;
        }

        private EncodedDocument TransformDocument(List<string> words)
        {
            var term_frequencies = words.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            var array = (float[])Array.CreateInstance(typeof(float), _tokenizer.Config.NumWords);
            
            foreach (var index in Enumerable.Range(0, _tokenizer.Config.NumWords))
            {
                if (!_tokenizer.Config.IndexWord.TryGetValue(index, out var word))
                    continue;

                if (!term_frequencies.ContainsKey(word))
                    continue;
                
                var documentFrequency = _tokenizer.Config.WordDocs[word];
                var innerLog = 1D + (_tokenizer.Config.DocumentCount / (1D + documentFrequency));
                var inverseDocumentFrequency = Math.Log(innerLog);

                var term_frequency = 1 + Math.Log(term_frequencies[word]);
                var tfidf = term_frequency * inverseDocumentFrequency;
                array[index] = (float)tfidf;
            }

            return new EncodedDocument(array);
        }
    }
}
