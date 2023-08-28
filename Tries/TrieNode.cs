namespace Tries;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; }

    public TrieNode()
    {
        Children = new Dictionary<char, TrieNode>();
    }
}

public class TrieSuggestions
{
    public List<string> Suggestions { get; }
    public Dictionary<char, TrieSuggestions> Children { get; }

    public TrieSuggestions()
    {
        Children = new Dictionary<char, TrieSuggestions>();
        Suggestions = new List<string>();
        
    }
}