namespace Tries.Test;

public class UnitTest1
{
    [Fact]
    public void CreateSomeTries()
    {
        string[] words = new string[] {"hello", "hell", "help", "goodbyte", "goodbye", "goose", "alpaca"};

        Samples samples = new Samples();

        TrieNode trieNode = samples.buildTrie(words);

        Assert.NotNull(trieNode);
    } 
    
    [Fact]
    public void GetSuggestions()
    {
        string[] words = new string[] {"hello", "hell", "help", "goodbyte", "goodbye", "goose", "alpaca"};

        Samples samples = new Samples();

        var result = samples.SuggestedProducts(words, "hell");

        Assert.NotNull(result);
    }
}