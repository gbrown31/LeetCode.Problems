namespace Tries.Test;

public class SuggestedProducts_Test
{
    private readonly SuggestedProducts suggestProducts;

    public SuggestedProducts_Test()
    {
        this.suggestProducts = new SuggestedProducts();
    }

    [Fact]
    public void GetSearchSuggestions()
    {
        string[] words = new string[] {"mobile", "mouse", "moneypot", "monitor", "mousepad"};
        string searchTerm = "mouse";

        var result = suggestProducts.GetSearchResults(words, searchTerm);

        Assert.NotNull(result);
    }
}