namespace BinarySearch.Test;

public class BinarySearch_Test
{
    private readonly BinarySearch search;

    public BinarySearch_Test()
    {
        this.search = new BinarySearch();
    }
    [Theory]
    [InlineData(new int[] {-1, 0, 3, 5, 9, 12}, 2, -1)]
    [InlineData(new int[] {-1, 0, 3, 5, 9, 12}, 9, 4)]
    public void FindTarget(int[] nums, int target, int expectedResult)
    {
        int result = search.FindTarget(nums, target);

        Assert.Equal(expectedResult, result);
    }


    [Fact]
    public void SearchMatrixForTarget()
    {
        int[][] matrix = new int[][] {new int[] {1, 3, 5, 7}, new int[] {10, 11, 16, 20}, new int[] {23, 30, 34, 60}};


        Assert.True(search.SearchMatrix(matrix, 3));
    }

    [Fact]
    public void SearchIndexOrInsert()
    {

        int[] nums = new int[] {1, 3, 5, 6};
        int result = search.SearchInsert(nums, 5);

        Assert.Equal(2, result);
    }

    [Fact]
    public void AnswerQueries()
    {

        int[] result = search.AnswerQueries(new int[] {4, 5, 2, 1}, new[] {3, 10, 21});

        int[] expectedResult = new int[] {2, 3, 4};

        for (int i = 0; i < expectedResult.Length; i++)
        {
            Assert.True(result[i] == expectedResult[i]);
        }
    }

    [Theory]
    [InlineData(new object[]{ new int[] { 55,30,5,4,2}, new int[] {100,20,10,10,5 }, 2})]
    [InlineData(new object[]{ new int[] { 2,2,2}, new int[] {10,10,1 }, 1})]
    public void FindMaxDistanceBetweenValidPairs(int[] nums1, int[] nums2, int expectedResult)
    {
        int maxDistance = search.MaxDistance(nums1, nums2);

        Assert.Equal(expectedResult, maxDistance);
    }
    
}