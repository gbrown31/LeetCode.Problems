namespace BinarySearch.Test;

public class SolutionSpace_Tests
{
    private readonly BinarySearch_SolutionSpaces solutionSpaces;

    public SolutionSpace_Tests()
    {
        this.solutionSpaces = new BinarySearch_SolutionSpaces();
    }
    [Theory]
    [InlineData(new object[] {new int[] {3, 6, 7, 11}, 8, 4})]
    [InlineData(new object[] {new int[] {30,11,23,4,20}, 5, 30})]
    public void FindMinimumSpeedKokEatingBananas(int[] piles, int timeLimit, int expectedMinimumEatingSpeed)
    {
        int result = solutionSpaces.MinEatingSpeed(piles, timeLimit);

        Assert.Equal(expectedMinimumEatingSpeed, result);
    }

    [Fact]
    public void CanTraverseGraphWithEffort()
    {
        int minimumEffort = solutionSpaces.MinimumEffortPath(new int[][]
            {new int[] {1, 2, 2}, new int[] {3, 8, 2}, new int[] {5, 3, 5}});

        Assert.Equal(2, minimumEffort);
    }
}