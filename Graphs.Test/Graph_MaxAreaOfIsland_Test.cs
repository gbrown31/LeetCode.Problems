namespace Graphs.Test;

public class Graph_MaxAreaOfIsland_Test
{
    [Fact]
    public void FindBiggestIslandOnMap()
    {
        Graph_MaxAreaOfIsland map = new Graph_MaxAreaOfIsland();
        int[][] coordinates = new int[][]
        {
            new int[] {0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0}, new int[] {0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
            new int[] {0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0}, new int[] {0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0},
            new int[] {0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0}, new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
            new int[] {0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0}, new int[] {0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0}
        };
        int mapAreaOfLand = map.MaxAreaOfIsland(coordinates);

        Assert.Equal(6, mapAreaOfLand);
    }
}