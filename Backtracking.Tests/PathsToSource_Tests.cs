namespace Backtracking.Tests;

public class PathsToSource_Tests
{
    [Fact]
    public void FindPathToSource()
    {
        PathsToSource paths = new PathsToSource();
        var result = paths.AllPathsSourceTarget(new int[][]
            {new int[] {1, 2}, new int[] {3}, new int[] {3}, new int[] { }});

        Assert.NotNull(result);
    }
}