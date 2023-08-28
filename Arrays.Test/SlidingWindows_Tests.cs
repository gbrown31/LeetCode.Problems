namespace Arrays.Test;

public class SlidingWindows_Tests
{
    private readonly SlidingWindows slidingWindows;

    public SlidingWindows_Tests()
    {
        this.slidingWindows = new SlidingWindows();
    }
    
    #region FindSubArraysOfZero
    [Fact]
    public void FindMaxSubArrayOfZeroes()
    {
        int[] myArray = new[] {0, 0, 0};

        long result = slidingWindows.GetZeroFilledSubarray(myArray);
        
        Assert.Equal(6, result);
    }

    [Theory]
    [InlineData(new object[] {new int[] {0, 0}, 3})]
    [InlineData(new object[] {new int[] {1, 3, 0, 0, 2, 0, 0, 4}, 6})]
    [InlineData(new object[] {new int[] {0, 0, 0, 2, 0, 0}, 9})]
    public void FindZeroFilledSubArrays(int[] nums, int expectedNo)
    {
        long noOfZeroes = slidingWindows.GetZeroFilledSubarray(nums);
        Assert.Equal(expectedNo, noOfZeroes);
    }
    #endregion
    
    #region GetNoOfZeroes
    
    [Fact]
    public void FindNoOfZeroes()
    {
        int[] myArray = new[] {0, 0, 0};

        long noOfZeroes = slidingWindows.GetNoOfZeroes(myArray);
        Assert.Equal(3, noOfZeroes);
    }

    [Theory]
    [InlineData(new object[] {new int[] {0, 0, 0}, 3})]
    [InlineData(new object[] {new int[] {0, 0, 0, 0}, 4})]
    [InlineData(new object[] {new int[] {0, 0, 0, 0, 1}, 4})]
    [InlineData(new object[] {new int[] {0, 0, 0, 0, 1, 2, 0}, 5})]
    [InlineData(new object[] {new int[] {10, 0, 0, 0, 0, 1, 2, 0}, 5})]
    [InlineData(new object[] {new int[] {10, 1, 2, 0}, 1})]
    [InlineData(new object[] {new int[] {10, 1, 2}, 0})]
    public void FindZeroesInArrays(int[] nums, int expectedNo)
    {
        long noOfZeroes = slidingWindows.GetNoOfZeroes(nums);
        Assert.Equal(expectedNo, noOfZeroes);
    }
    #endregion
    
    #region MaxContainerVolumeInArray

    [Fact]
    public void GetMaxVolumeOfArray()
    {
        int[] heights = new[] {1, 8, 6, 2, 5, 4, 8, 3, 7};
        int result = slidingWindows.GetMaxArea(heights);

        Assert.Equal(49, result);
    }
    [Theory]
    [InlineData(new object[]{ new[] {1, 1 }, 1 })]
    [InlineData(new object[]{ new[] {2, 2 }, 2 })]
    [InlineData(new object[]{ new[] {2, 4, 2 }, 4 })]
    [InlineData(new object[]{ new[] {1, 8, 6, 2, 5, 4, 8, 3, 7}, 49 })]
    public void GetMaxVolumeOfArrays(int[] heights, int expectedVolume)
    {
        int result = slidingWindows.GetMaxArea(heights);

        Assert.Equal(expectedVolume, result);
    }
    #endregion

    [Fact]
    public void GetMaxConsecutive()
    {
        int[] nums = new[] {1, 1, 0, 0, 0};
        int result = slidingWindows.GetMaxConsecutiveOnes(nums, 2);

        Assert.Equal(4, result);
    }
}