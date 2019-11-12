# tfidf in c#

[tf-idf] (https://en.wikipedia.org/wiki/Tf%E2%80%93idf)

This library can import pretrained [keras tokenizer](https://keras.io/preprocessing/text/), which were exported in json format. With the imported tokenizer it is possible to transform text with tfidf.
To use tokenization per word use WordStrategy, for per character tokenization use CharacterStrategy.

For examples have a look at the unit tests.