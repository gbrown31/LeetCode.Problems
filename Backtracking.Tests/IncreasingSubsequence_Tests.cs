namespace Backtracking.Tests;

public class IncreasingSubsequence_Tests
{
    [Theory]
    [InlineData(new object[] {new int[] {4, 6, 7, 7}, 8})]
    [InlineData(new object[] {new int[] {4, 4, 3, 2, 1}, 1})]
    public void FindIncreasingSubseq(int[] nums, int expectedResults)
    {
        IncreasingSubsequences subsequences = new IncreasingSubsequences();

        var result = subsequences.FindSubsequences(nums);

        Assert.Equal(expectedResults, result.Count);
    }
}