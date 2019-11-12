using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using TFIDF.keras;

namespace TFIDF.UnitTests
{
    [TestFixture]
    public class TFIDFCalcTests
    {
        [Test]
        public void IfSimpleWordsAreEncoded_ThenItShouldBeCorrectly()
        {
            // Arrange
            var originalText = "hallo test nicht";
            var expected_string = File.ReadAllText(@"Content/encoded/encoded_simple_words.json", Encoding.UTF8);
            var expected = JsonConvert.DeserializeObject<List<List<float>>>(expected_string);

            var tokenizer_simple_words_json = File.ReadAllText(@"Content/tokenizer/tokenizer_simple_words.json", Encoding.UTF8);
            var tokenizer_simple_words = Tokenizer.FromJson(tokenizer_simple_words_json);
            var tfidfCalc = new TFIDFCalc(tokenizer_simple_words);

            // Act
            var resultDocuments = tfidfCalc.TextsToMatrix(new List<string> { originalText });

            // Assert
            var resultTransformation = resultDocuments.Single().EncodedWords;

            PrintDebugExpectedAndResult(expected, resultDocuments);

            resultTransformation.Should().HaveCount(expected.Single().Count);

            resultTransformation.Should().ContainInOrder(expected.Single());
        }

        [Test]
        public void IfSimpleCharsAreEncoded_ThenItShouldBeCorrectly()
        {
            // Arrange
            var originalText = "hallo test nicht";
            var expected_string = File.ReadAllText(@"Content/encoded/encoded_simple_chars.json", Encoding.UTF8);
            var expected = JsonConvert.DeserializeObject<List<List<float>>>(expected_string);

            var tokenizer_simple_chars_json = File.ReadAllText(@"Content/tokenizer/tokenizer_simple_chars.json", Encoding.UTF8);
            var tokenizer_simple_chars = Tokenizer.FromJson(tokenizer_simple_chars_json);
            var tfidfCalc = new TFIDFCalc(tokenizer_simple_chars);

            // Act
            var resultDocuments = tfidfCalc.TextsToMatrix(new List<string> { originalText });

            // Assert
            var resultTransformation = resultDocuments.Single().EncodedWords;

            PrintDebugExpectedAndResult(expected, resultDocuments);

            resultTransformation.Should().HaveCount(expected.Single().Count);
            resultTransformation.Should().ContainInOrder(expected.Single());
        }

        private void PrintDebugExpectedAndResult(List<List<float>> expected, List<TFIDFCalc.EncodedDocument> encodedDocuments)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Expected");
            for (var i = 0; i < expected.Count; i++)
            {
                for (var j = 0; j < expected[0].Count; j++)
                {
                    sb.Append(expected[i][j]);
                    sb.Append(", ");
                }

                sb.AppendLine();
            }

            sb.Append("####################");
            sb.AppendLine("Actual");

            for (var i = 0; i < encodedDocuments.Count; i++)
            {
                for (var j = 0; j < encodedDocuments[0].EncodedWords.Length; j++)
                {
                    sb.Append(encodedDocuments[i].EncodedWords[j]);
                    sb.Append(", ");
                }

                sb.AppendLine();
            }

            Debug.Write(sb.ToString());
        }

        public class TokenizerInfo
        {
            [JsonProperty("transformed")]
            public List<List<float>> Transformed { get; set; }

            [JsonProperty("original")]
            public List<string> Original { get; set; }

            public static TokenizerInfo FromJson(string json) => JsonConvert.DeserializeObject<TokenizerInfo>(json);
        }
    }
}
