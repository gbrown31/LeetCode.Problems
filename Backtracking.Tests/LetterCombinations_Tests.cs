namespace Backtracking.Tests;

public class LetterCombinations_Tests
{
    [Fact]
    public void GetLetterCombinations()
    {
        LetterCombinationsOfPhoneKey letters = new LetterCombinationsOfPhoneKey();
        IList<string> results = letters.LetterCombinations("23");

        Assert.True(results.Count > 5);

    }
}