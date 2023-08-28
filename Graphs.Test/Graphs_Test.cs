namespace Graphs.Test;

public class Graphs_Test
{
    private readonly Graphs graphs;
    private static readonly int[][] multiDimensionalArray1 = new int[][] {new int[] {1, 1, 0}, new int[] {1, 1, 0}, new int[] {0, 0, 1}};

    public Graphs_Test()
    {
        this.graphs = new Graphs();
    }
    
    [Fact]
    public void FindCircleNum()
    {
        int[][] multiDimensionalArray = new int[][] {new int[] {1, 1, 0}, new int[] {1, 1, 0}, new int[] {0, 0, 1}};
        int output = graphs.FindCircleNum(multiDimensionalArray);

        Assert.Equal(2, output);
    }

    [Fact]
    public void FindIsland()
    {
        char[][] map = new char[][]
        {
            new char[] {'1', '1', '1', '1', '0'}, 
            new char[] {'1', '1', '0', '1', '0'},
            new char[] {'1', '1', '0', '0', '0'}, 
            new char[] {'0', '0', '0', '0', '0'}
        };
        int island = graphs.NumIslands(map);
        Assert.Equal(1, island);
    }
}