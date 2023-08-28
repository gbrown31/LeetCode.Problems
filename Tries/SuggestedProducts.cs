namespace Tries;

public class SuggestedProducts
{
    private char endOfWord = '*';
    private TrieNode root;
    
    public IList<IList<string>> GetSearchResults(string[] products, string searchWord) 
    {
        List<IList<string>> results = new List<IList<string>>();
        root = new TrieNode();
        foreach(string word in products)
        {
            TrieNode curr = root;
            foreach(char c in word)
            {
                if(!curr.Children.ContainsKey(c))
                {
                    curr.Children.Add(c, new TrieNode());
                }
                curr = curr.Children[c];
            }
            curr.Children.Add(endOfWord, new TrieNode());
        }
        
        string searchTerm = string.Empty;
        foreach(char c in searchWord)
        {
            searchTerm += c;
            results.Add(search(searchTerm));
        }
        return results;
    }
    
    private IList<string> search(string search)
    {
        List<string> suggestions = new List<string>();
        TrieNode curr = root;
        foreach(char c in search)
        {
            if(curr.Children.ContainsKey(c))
            {
                
                curr = curr.Children[c];
                
                
                List<char> word = new List<char>();
                Stack<TrieNode> stack = new Stack<TrieNode>();
                stack.Push(curr);
                word.Add(c);
                
                
                while(stack.Count > 0)
                {
                    TrieNode node = stack.Pop();                
                    foreach(char key in node.Children.Keys)
                    {
                        if(key == endOfWord)
                        {
                            suggestions.Add(new String(word.ToArray()));
                        }
                        else
                        {
                            word.Add(key);
                            stack.Push(node.Children[key]);
                        }
                    }
                }
            }            
        }
        
        return suggestions;
    }
}