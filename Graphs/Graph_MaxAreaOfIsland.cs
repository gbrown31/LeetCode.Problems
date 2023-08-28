using System.Diagnostics.SymbolStore;

namespace Graphs;

public class Graph_MaxAreaOfIsland
{
    private HashSet<string> visitedCoordinates = new HashSet<string>();
    public int MaxAreaOfIsland(int[][] grid)
    {
        Dictionary<string, int> coordinatesAndLandMassCount = new Dictionary<string, int>();
        int rowCount = grid.Length,
            colCount = grid[0].Length;
        // loop across grid
        // loop down group
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                // add coordinates as being visited
                string coordinates = getCoordinates(row, col);
                // find first node that matches 1
                if (grid[row][col] == 1 && !visitedCoordinates.Contains(coordinates))
                {
                    visitedCoordinates.Add(coordinates);
                    int connectedLandMass = findNumberOfConnectedLandMass(grid, row, col);
                    // depth first search in 4 directions for more land mass
                    coordinatesAndLandMassCount.Add(coordinates, connectedLandMass + 1);
                    // store coordinates and size of map in Dictionary
                }
            }
        }
        // find max count of size in dictionary and return
        if (coordinatesAndLandMassCount.Count > 0)
        {
            return coordinatesAndLandMassCount.Max(a => a.Value);
        }
        else return 0;
    }

    private int findNumberOfConnectedLandMass(int[][] grid, int row, int col)
    {
        int landMassFound = 0;
        // based on the current row and col
        // navigate around the map in 4 directions to find if any of those
        int[][] directions = new int[][] {new int[] {0, 1}, new int[] {0, -1}, new int[] {1, 0}, new int[] {-1, 0}};
        foreach (int[] direction in directions)
        {
            int newRow = row + direction[0],
                newCol = col + direction[1];
            string coordinates = getCoordinates(newRow, newCol);
            if (!visitedCoordinates.Contains(coordinates) && isValidLandMass(grid, newRow, newCol))
            {
                visitedCoordinates.Add(coordinates);
                landMassFound++;

                landMassFound += findNumberOfConnectedLandMass(grid, newRow, newCol);
            }
        }
        // coordinates are also a land mass
        // only visit coordinates not already visited
        return landMassFound;
    }

    private bool isValidLandMass(int[][] grid, int newRow, int newCol)
    {
        bool isValid = false;

        if (newCol >= 0 && newRow >= 0 && newRow < grid.Length && newCol < grid[0].Length && grid[newRow][newCol] == 1)
        {
            isValid = true;
        }

        return isValid;
    }

    private string getCoordinates(int row, int col)
    {
        return $"{row},{col}";
    }
}