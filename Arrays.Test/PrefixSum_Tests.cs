namespace Arrays.Test;

public class PrefixSum_Tests
{
    private readonly PrefixSum prefixSum;

    public PrefixSum_Tests()
    {
        this.prefixSum = new PrefixSum();
    }
    
    [Fact]
    public void GetPrefixSum()
    {
        int[] nums = new[] {1, 2, 3};
        int[] prefix = prefixSum.GetPrefixSum(nums);

        Assert.Equal(1, prefix[0]);
        Assert.Equal(6, prefix[2]);
    }
    
    [Theory]
    [InlineData(new object[]{new[] {1, 2, 3}, new []{1,3,6} })]
    [InlineData(new object[]{new[] {1, 2, 3, 4}, new []{1,3,6, 10} })]
    [InlineData(new object[]{new[] {10, 2, 3}, new []{10,12,15} })]
    public void GetPrefixSums(int[] nums, int[] expectedPrefix)
    {
        int[] prefix = prefixSum.GetPrefixSum(nums);

        for (int i = 0; i < prefix.Length; i++)
        {
            Assert.Equal(expectedPrefix[i], prefix[i]);
        }
    }

    [Fact]
    public void IsSubArrayWithinLimit()
    {
        bool[] expectedAnswers = new bool[] {true, false, true};
        int[] nums = new[] {1, 6, 3, 2, 7, 2};
        int[][] queries = new[] {new int[2] {0, 3}, new int[2] {2, 5}, new int[] {2, 4}};

        bool[] answers = prefixSum.AnswerQueries(nums, queries, 13);

        for (int i = 0; i < answers.Length; i++)
        {
            Assert.Equal(expectedAnswers[i], answers[i]);
        }
    }

    [Theory]
    [InlineData(new object[]{new[] {1, 2, 3}, 0})]//, new []{1,3,6} })]
    [InlineData(new object[]{new[] {1, 2, 3, 4}, 1})]//, new []{1,3,6, 10} })]
    [InlineData(new object[]{new[] {10, 2, 3}, 2})]//, new []{10,12,15} })]
    public void GetNumOfSplitArrayWithBiggerLeft(int[] nums, int expectedBiggerSplits)
    {
        int result = prefixSum.GetNumOfSplitArrayWithBiggerLeft(nums);
        
        Assert.Equal(expectedBiggerSplits, result);
    }
    [Theory]
    [InlineData(new object[]{new[] {2, 5, 3, 9, 5, 3}, 3})]
    [InlineData(new object[]{new[] {1, 1, 1, 1, 1}, 0})]
    [InlineData(new object[]{new[] {0}, 0})]
    public void GetMinimumAverageDifference(int[] nums, int expectedIndex)
    {
        int result = prefixSum.GetMinimumAverageDifference(nums);

        Assert.Equal(expectedIndex, result);
    }
}