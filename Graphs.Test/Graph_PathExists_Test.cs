namespace Graphs.Test;

public class Graph_PathExists_Test
{
    private readonly Graph_PathExists graphPath;

    public Graph_PathExists_Test()
    {
        this.graphPath = new Graph_PathExists();
    }

    [Fact]
    public void CheckIfPathExists()
    {
        int n = 3,
            source = 0,
            destionation = 2;
        int[][] edges = new int[][] {new int[] {0, 1}, new int[] {1, 2}, new int[] {2, 0}};

        bool validPath = graphPath.ValidPath(n, edges, source, destionation);

        Assert.True(validPath);
    }
}