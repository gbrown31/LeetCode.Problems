namespace Heaps.Test
{
    public class TopKFrequentWords_Test
    {
        [Fact]
        public void Test()
        {
            string[] words = new string[] { "i", "love", "leetcode", "i", "love", "coding" };

            IList<string> popularWords = GetKPopularWords(words, 3);

            Assert.Contains("coding", popularWords);
            Assert.Contains("i", popularWords);
            Assert.Contains("love", popularWords);
        }

        private IList<string> GetKPopularWords(string[] words, int k)
        {
            // create a dictionary<string, int> to count the words
            // push them onto a max heap
            // iterate over the heap k times to find the most popular words

            Dictionary<string, int> wordPopularity = new();
            foreach (string word in words)
            {
                if (wordPopularity.ContainsKey(word))
                {
                    wordPopularity[word] += 1;
                }
                else
                {
                    wordPopularity.Add(word, 1);
                }
            }

            PriorityQueue<string, WordCount> maxHeap = new(Comparer<WordCount>.Create((x, y) => x.CompareTo(y)));
            foreach (string key in wordPopularity.Keys)
            {
                maxHeap.Enqueue(key, new WordCount(key, wordPopularity[key]));
            }

            List<string> mostKPopularWords = new();
            while (k > 0)
            {
                mostKPopularWords.Add(maxHeap.Dequeue());
                k--;
            }
            return mostKPopularWords;
        }
        private class WordCount : IComparable<WordCount>
        {
            public string Word { get; }
            public int Count { get; }
            public WordCount(string word, int count)
            {
                this.Word = word;
                this.Count = count;
            }

            public int CompareTo(WordCount? other)
            {
                if (other.Count != this.Count)
                {
                    return other.Count.CompareTo(this.Count);
                }
                else
                {
                    return Word.CompareTo(other.Word);
                }
            }
        }
    }
}
