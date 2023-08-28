namespace Tries;

public class Samples
{
    public TrieNode buildTrie(String[] words)
    {
        TrieNode root = new TrieNode();
        foreach (string word in words)
        {
            TrieNode curr = root;
            foreach (char c in word)
            {
                if (!curr.Children.ContainsKey(c))
                {
                    curr.Children.Add(c, new TrieNode());
                }

                curr = curr.Children[c];
            }

            // at this point, you have a full word at curr
            // you can perform more logic here to give curr an attribute if you want
        }

        return root;
    }

    public List<List<string>> SuggestedProducts(string[] products, string searchWord)
    {
        TrieSuggestions root = new TrieSuggestions();
        foreach (string product in products)
        {
            TrieSuggestions node = root;
            foreach (char c in product)
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children.Add(c, new TrieSuggestions());
                }

                node = node.Children[c];

                node.Suggestions.Add(product);
                //Collections.sort(node.Suggestions);
                if (node.Suggestions.Count > 3)
                {
                    node.Suggestions.RemoveAt(node.Suggestions.Count);
                }
            }
        }

        List<List<string>> ans = new List<List<string>>();
        TrieSuggestions answerNode = root;

        foreach (char c in searchWord) {
            if (answerNode.Children.ContainsKey(c))
            {
                answerNode = answerNode.Children[c];
                ans.Add(answerNode.Suggestions);
            }
            else
            {
                // deadend reached
                //node.Children = new Dictionary<char, TrieSuggestions>();
                ans.Add(new List<string>());
            }
        }

        return ans;
    }
}