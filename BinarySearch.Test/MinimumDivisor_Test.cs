namespace BinarySearch.Test;

public class MinimumDivisor_Test
{
    [Fact]
    public void GetMinimumDivisorWithinThreshold()
    {
        MinimumDivisor divisor = new MinimumDivisor();

        int result = divisor.SmallestDivisor(new int[] {1, 2, 5, 9}, 6);

        Assert.Equal(5, result);
    }
}