namespace BinarySearch.Test;

public class BinarySearch_MaxDistance_Test
{
    [Theory]
    [InlineData(new object[] {new int[] {2, 2, 2}, new int[] {10, 10, 1}, 1})]
    [InlineData(new object[] {new int[] {55, 30, 5, 4, 2}, new int[] {100, 20, 10, 10, 5}, 2})]
    [InlineData(new object[] {new int[] {30, 29, 19, 5}, new int[] {25, 25, 25, 25, 25}, 2})]
    public void FindMaxDistanceBetweenValidPairs(int[] nums1, int[] nums2, int expectedResult)
    {
        BinarySearch_MaxDistance bsDistance = new BinarySearch_MaxDistance();

        int maxDistance = bsDistance.MaxDistance(nums1, nums2);

        Assert.Equal(expectedResult, maxDistance);
    }
}