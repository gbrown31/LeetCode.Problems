namespace Tries;

public class MapSum
{
    private class ATrieNode 
    {
        public int Val { get; set; }
        public bool EndOfWord { get; set; }
        
        public Dictionary<char, ATrieNode> Children { get; }

        public ATrieNode()
        {
            Children = new Dictionary<char, ATrieNode>();
        }
    }
    private readonly ATrieNode root;
    public MapSum() 
    {
        root = new ATrieNode();   
    }
    
    public void Insert(string key, int val) 
    {
        ATrieNode curr = root;
        foreach(char c in key)
        {
            if(!curr.Children.ContainsKey(c))
            {
                curr.Children.Add(c, new ATrieNode());
            }
            curr = curr.Children[c];
        }
        // reached the end of the word, set the value of the node
        curr.Val = val;
        curr.EndOfWord = true;
    }
    
    public int Sum(string prefix) 
    {
        Console.WriteLine($"Sum call with {prefix}");
        int totalSumOfWordsForPrefix = 0;
        if(!string.IsNullOrEmpty(prefix))
        {
            ATrieNode curr = root;
            // loop the prefix, looking for child nodes
            foreach(char c in prefix)
            {
                if(curr.Children.ContainsKey(c))
                {
                    curr = curr.Children[c];
                }
                else
                {
                    // we've not found the characters we're looking for
                    return 0;
                }
            }

            // curr should now be the deepest child that matches our prefix search
            // dfs the remaining child nodes to find the values of the words in the Trie
            Stack<ATrieNode> stack = new Stack<ATrieNode>();
            stack.Push(curr);
            if(curr.EndOfWord)
            {
                totalSumOfWordsForPrefix += curr.Val;
            }
            List<int> foundWordValues = new List<int>();
            Console.WriteLine("List created");

            while(stack.Count>0)
            {
                ATrieNode node = stack.Pop();

                // add children to the stack
                foreach(char key in node.Children.Keys)
                {
                    Console.WriteLine($"{key} {node.Children[key].EndOfWord}");
                    // could check here for end of word nodes?
                    if(node.Children[key].EndOfWord)
                    {
                        Console.WriteLine($"{totalSumOfWordsForPrefix} {node.Children[key].Val}");
                        // found end of word
                        totalSumOfWordsForPrefix = totalSumOfWordsForPrefix+ node.Children[key].Val; 
                        foundWordValues.Add(node.Children[key].Val);
                        Console.WriteLine($"{foundWordValues.Sum()}");
                    }
                    else
                    {
                        // push child node onto the stack
                        stack.Push(node.Children[key]);
                    }
                }
            }            
        }
        return totalSumOfWordsForPrefix;
    }
}