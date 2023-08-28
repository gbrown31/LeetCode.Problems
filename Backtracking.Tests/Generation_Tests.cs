namespace Backtracking.Tests;

public class Generation_Tests
{
    [Fact]
    public void GetAllPermutations()
    {
        Generation gen = new Generation();

        var result = gen.Permute(new int[] {1, 2, 3});

        Assert.True(result.Count == 6);
    }
}