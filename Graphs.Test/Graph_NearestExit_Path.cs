namespace Graphs.Test;

public class Graph_NearestExit_Path
{
    [Fact]
    public void FindNearestExitInMaze()
    {
        var maze = new char[][]
        {
            new char[] {'+', '+', '.', '+'}, new char[] {'.', '.', '.', '+'}, new char[] {'+', '+', '+', '.'}
        };

        Graph_NearestExit nearestExit = new Graph_NearestExit();

        int output = nearestExit.NearestExit(maze, new int[] {1, 2});

        Assert.Equal(1, output);
    }
    
    [Fact]
    public void FindNearestExitInMaze_AvoidingEntrace()
    {
        var maze = new char[][]
        {
            new char[] {'+','+','+'}, new char[] {'.','.','.'}, new char[] {'+','+','+'}
        };

        Graph_NearestExit nearestExit = new Graph_NearestExit();

        int output = nearestExit.NearestExit(maze, new int[] {1, 0});

        Assert.Equal(2, output);
    }
}