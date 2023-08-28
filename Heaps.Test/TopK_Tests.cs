namespace Heaps.Test;

public class TopK_Tests
{
    [Theory]
    [InlineData(new object[]{ new int[] { 1, 1, 1, 2, 2, 3}, 2, new int[] {1,2}})]
    [InlineData(new object[]{ new int[] {1,2}, 2, new int[] {1,2}})]
    [InlineData(new object[]{ new int[] {5,3,1,1,1,3,73,1}, 2, new int[] {1,3}})]
    public void GetTopKElements(int[] nums, int k, int[] expectedResult)
    {
        TopK top = new TopK();
        int[] result = top.TopKFrequent(nums, k);

        Assert.True(result.Length > 0);
        foreach (int i in expectedResult)
        {
            Assert.True(result.Contains(i));
        }
    }
}