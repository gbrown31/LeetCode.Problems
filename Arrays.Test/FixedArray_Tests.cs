namespace Arrays.Test;

public class FixedArray_Tests
{
    private readonly FixedWindow fixedWindow;

    public FixedArray_Tests()
    {
        this.fixedWindow = new FixedWindow();
    }
    
    [Fact]
    public void GetMaxAverageSubArray()
    {
        int[] nums = new[] {1, 12, -5, -6, 50, 3};

        double result = fixedWindow.FindMaxAverage(nums, 4);

        Assert.Equal(12.75000, result);
    }
}