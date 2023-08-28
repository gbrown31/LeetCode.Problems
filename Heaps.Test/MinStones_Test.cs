namespace Heaps.Test;

public class MinStones_Test
{
    [Fact]
    public void GetSumOfStones()
    {
        int[] pilesOfStones = new int[] {5, 4, 9};
        Heaps_MinStones stones = new Heaps_MinStones();

        int result = stones.MinStoneSum(pilesOfStones, 2);

        Assert.Equal(12, result);
    }
}