using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using TFIDF.keras;

namespace TFIDFTests.keras
{
    [TestFixture]
    public class TokenizerTests
    {
        [Test]
        public void IfAWordTokenizerIsLoaded_ThenItShouldBeLoadedCorrectly()
        {
            // Arrange
            var loadedJson = File.ReadAllText(@"Content\tokenizer\tokenizer_simple_words.json", Encoding.UTF8);

            var expectedIndexDocs = new Dictionary<int, int> { { 3, 2 }, { 1, 3 }, { 2, 2 }, { 4, 1 }, { 5, 1 } };
            var expectedWordCounts = new Dictionary<string, int>
                                     { { "hallo", 3 }, { "dies", 1 }, { "ist", 2 }, { "ein", 2 }, { "test", 1 } };
            var expectedWordDocs = new Dictionary<string, int>
                                   { { "ein", 2 }, { "hallo", 3 }, { "ist", 2 }, { "dies", 1 }, { "test", 1 } };
            var expectedIndexWord = new Dictionary<int, string>
                                    { { 1, "hallo" }, { 2, "ist" }, { 3, "ein" }, { 4, "dies" }, { 5, "test" } };
            var expectedWordIndex = new Dictionary<string, int>
                                    { { "hallo", 1 }, { "ist", 2 }, { "ein", 3 }, { "dies", 4 }, { "test", 5 } };

            // Act
            var tokenizer = Tokenizer.FromJson(loadedJson);

            // Assert
            var config = tokenizer.Config;
            config.CharLevel.Should().BeFalse();
            config.Filters.Should().BeEmpty();
            config.Lower.Should().BeTrue();

            config.DocumentCount.Should().Be(3);
            config.NumWords.Should().Be(6);

            config.IndexDocs.Should().Contain(expectedIndexDocs);
            config.IndexDocs.Should().HaveCount(expectedIndexDocs.Count);

            config.WordCounts.Should().Contain(expectedWordCounts);
            config.WordCounts.Should().HaveCount(expectedWordCounts.Count);

            config.WordDocs.Should().Contain(expectedWordDocs);
            config.WordDocs.Should().HaveCount(expectedWordDocs.Count);

            config.IndexWord.Should().Contain(expectedIndexWord);
            config.IndexWord.Should().HaveCount(expectedIndexWord.Count);

            config.WordIndex.Should().Contain(expectedWordIndex);
            config.WordIndex.Should().HaveCount(expectedWordIndex.Count);
        }

        [Test]
        public void IfACharTokenizerIsLoaded_ThenItShouldBeLoadedCorrectly()
        {
            // Arrange
            var loadedJson = File.ReadAllText(@"Content\tokenizer\tokenizer_simple_chars.json", Encoding.UTF8);

            var expectedWordCounts = new Dictionary<string, int>
                                     {
                                         { "h", 3 }, { "a", 3 }, { "l", 6 }, { "o", 3 }, { " ", 6 }, { "d", 1 }, { "i", 5 }, { "e", 4 }, { "s", 4 }, { "t", 4 },
                                         { "n", 2 }
                                     };
            var expectedWordDocs = new Dictionary<string, int>
                                   {
                                       { "l", 3 }, { "d", 1 }, { "a", 3 }, { "s", 2 }, { "i", 3 }, { "t", 2 }, { "e", 2 }, { " ", 3 }, { "h", 3 }, { "n", 2 },
                                       { "o", 3 }
                                   };
            var expectedIndexDocs = new Dictionary<int, int>
                                    { { 1, 3 }, { 11, 1 }, { 8, 3 }, { 5, 2 }, { 3, 3 }, { 6, 2 }, { 4, 2 }, { 2, 3 }, { 7, 3 }, { 10, 2 }, { 9, 3 } };
            var expectedIndexWord = new Dictionary<int, string>
                                    {
                                        { 1, "l" }, { 2, " " }, { 3, "i" }, { 4, "e" }, { 5, "s" }, { 6, "t" }, { 7, "h" }, { 8, "a" }, { 9, "o" }, { 10, "n" },
                                        { 11, "d" }
                                    };
            var expectedWordIndex = new Dictionary<string, int>
                                    {
                                        { "l", 1 }, { " ", 2 }, { "i", 3 }, { "e", 4 }, { "s", 5 }, { "t", 6 }, { "h", 7 }, { "a", 8 }, { "o", 9 }, { "n", 10 },
                                        { "d", 11 }
                                    };

            // Act
            var tokenizer = Tokenizer.FromJson(loadedJson);

            // Assert
            var config = tokenizer.Config;
            config.CharLevel.Should().BeTrue();
            config.Filters.Should().BeEmpty();
            config.Lower.Should().BeTrue();

            config.DocumentCount.Should().Be(3);
            config.NumWords.Should().Be(6);

            config.IndexDocs.Should().Contain(expectedIndexDocs);
            config.IndexDocs.Should().HaveCount(expectedIndexDocs.Count);

            config.WordCounts.Should().Contain(expectedWordCounts);
            config.WordCounts.Should().HaveCount(expectedWordCounts.Count);

            config.WordDocs.Should().Contain(expectedWordDocs);
            config.WordDocs.Should().HaveCount(expectedWordDocs.Count);

            config.IndexWord.Should().Contain(expectedIndexWord);
            config.IndexWord.Should().HaveCount(expectedIndexWord.Count);

            config.WordIndex.Should().Contain(expectedWordIndex);
            config.WordIndex.Should().HaveCount(expectedWordIndex.Count);
        }
    }
}
