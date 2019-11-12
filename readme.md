# term frequency–inverse document frequency (tf-idf) in c#

This library can import pretrained [keras tokenizer](https://keras.io/preprocessing/text/), which were exported in json format. With the imported tokenizer it is possible to transform text with [tf-idf](https://en.wikipedia.org/wiki/Tf-idf).
To use tokenization per word use WordStrategy, for per character tokenization use CharacterStrategy. This is the same behavior as setting the char_level property on the tokenizer.

# how-to
## train export tokenizer
```python
from keras.preprocessing.text import Tokenizer
tokenizer = Tokenizer(num_words=tokenizer_word_count, char_level=False, filters='', split=' ')
all_words = "abc def"
tokenizer.fit_on_texts(all_words)

tokenizer_json = tokenizer.to_json()
with open(output_directory + "tokenizer.json", "w", encoding="utf-8") as text_file:
    print(tokenizer_json, file=text_file)
```
## import tokenizer in c#
```csharp
var loadedJson = File.ReadAllText(@"tokenizer.json", Encoding.UTF8);
tokenizer = Tokenizer.FromJson(loadedJson);
```

For examples have a look at the unit tests.
