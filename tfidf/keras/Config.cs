using System.Collections.Generic;
using Newtonsoft.Json;

namespace TFIDF.keras
{
    public class Config
    {
        [JsonProperty("num_words")]
        public int NumWords { get; set; }

        [JsonProperty("filters")]
        public string Filters { get; set; }

        [JsonProperty("lower")]
        public bool Lower { get; set; }

        [JsonProperty("split")]
        public string Split { get; set; }

        [JsonProperty("char_level")]
        public bool CharLevel { get; set; }

        [JsonProperty("oov_token")]
        public object OovToken { get; set; }

        [JsonProperty("document_count")]
        public long DocumentCount { get; set; }

        [JsonProperty("word_counts")]
        public Dictionary<string, int> WordCounts { get; set; }

        [JsonProperty("word_docs")]
        public Dictionary<string, int> WordDocs { get; set; }

        [JsonProperty("index_docs")]
        public Dictionary<int, int> IndexDocs { get; set; }

        [JsonProperty("index_word")]
        public Dictionary<int, string> IndexWord { get; set; }

        [JsonProperty("word_index")]
        public Dictionary<string, int> WordIndex { get; set; }
    }
}
