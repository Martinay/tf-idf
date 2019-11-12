using Newtonsoft.Json;

namespace TFIDF.keras
{
    public class Tokenizer
    {
        [JsonProperty("class_name")]
        public string ClassName { get; set; }

        [JsonProperty("config")]
        public Config Config { get; set; }

        public static Tokenizer FromJson(string json)
        {
            json = json.Replace(" \"{", " {");
            json = json.Replace("}\"", "}");
            json = json.Replace("\\\"", "\"");

            return JsonConvert.DeserializeObject<Tokenizer>(json);
        }
    }
}
