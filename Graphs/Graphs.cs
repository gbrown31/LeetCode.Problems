namespace Graphs;

public class Graphs
{
    private Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
    private bool[] seen = null;
    private HashSet<string> landIdentifiersFound = new HashSet<string>();

    public int FindCircleNum(int[][] isConnected)
    {
        // build graph of node indexes and connected indexes
        //Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        // loop the multi dimensional array, nxn
        int n = isConnected.Length;
        // loop the first array
        for (int i = 0; i < n; i++)
        {
            // if the node hasn't been visited then add it
            if (!graph.ContainsKey(i))
            {
                graph.Add(i, new List<int>());
            }

            // loop the connections of node i
            // loop the 2nd/3rd items of i=1
            // loop the 3rd items of i=2
            //  - this j=i+1 mechanisn means that for every
            //  loop of i we are starting j 1 position to the right
            //  so that we only traverse the required nodes of the matrix
            //  as the rest of the matrix nodes would show the relationship inverse
            for (int j = i + 1; j < n; j++)
            {
                if (!graph.ContainsKey(j))
                {
                    graph.Add(j, new List<int>());
                }

                // find if nodes are connected
                if (isConnected[i][j] == 1)
                {
                    // j is a neighbour of i
                    // i is a neighbour of j
                    graph[i].Add(j);
                    graph[j].Add(i);
                }
            }
        }

        seen = new bool[n];
        int answer = 0;
        for (int i = 0; i < n; i++)
        {
            if (!seen[i])
            {
                answer++;
                seen[i] = true;
                dfsStack(i);
            }
        }

        return answer;
    }
    public int NumIslands(char[][] grid)
    {
        int islandsFound = 0;
        // is nxm graph
        // so find the length of n and length of m
        int numberOfRows = grid.Length, // number of rows
            numberOfColumns = grid[0].Length; // number of columns

        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {
                string landIdentifier = getLandIndentifier(i, j);
                //grid[i][j] is value at row and column index
                if (grid[i][j] == '1' && !landIdentifiersFound.Contains(landIdentifier))
                {
                    islandsFound++;
                    landIdentifiersFound.Add(landIdentifier);
                    traverseJoiningLandMass(i, j, grid);
                }
            }
        }

        return islandsFound;
    }

    private HashSet<string> roads = new HashSet<string>();
    private Dictionary<int, List<int>> cityNeighbours = new Dictionary<int, List<int>>();
    private HashSet<int> citiesVisited = new HashSet<int>();
    public int MinReorder(int n, int[][] connections)
    {
        // populate Cities
        for (int i = 0; i < n; i++)
        {
            cityNeighbours.Add(i, new List<int>());
        }

        // populate neighbours and roads
        foreach (int[] connection in connections)
        {
            int x = connection[0],
                y = connection[1];

            cityNeighbours[x].Add(y);
            cityNeighbours[y].Add(x);
            roads.Add(getRoadName(x, y));
        }

        citiesVisited.Add(0);

        return traverseRoadsAwayCity(0);
    }

    private int traverseRoadsAwayCity(int cityIndex)
    {
        int answer = 0;
        foreach (int neighbour in cityNeighbours[cityIndex])
        {
            if (!citiesVisited.Contains(neighbour))
            {
                if (roads.Contains(getRoadName(cityIndex, neighbour)))
                {
                    answer++;
                }

                citiesVisited.Add(neighbour);
                answer += traverseRoadsAwayCity(neighbour);
            }
        }

        return answer;
    }

    private string getRoadName(int i, int i1)
    {
        return $"{i}to{i1}";
    }

    private void traverseJoiningLandMass(int startRow, int startCol, char[][] grid)
    {
        // can move up, down, left right
        // row +-1, col +- 1?
        int[][] availableDirections = new int[][]
            {new int[] {0, 1}, new int[] {1, 0}, new int[] {-1, 0}, new int[] {0, -1}};

        foreach (int[] direction in availableDirections)
        {
            int nextRow = startRow + direction[0],
                nextCol = startCol + direction[1];

            string landIndentifier = getLandIndentifier(nextRow, nextCol);
            if (isLandMass(grid, nextRow, nextCol) && !landIdentifiersFound.Contains(landIndentifier))
            {
                landIdentifiersFound.Add(landIndentifier);
                traverseJoiningLandMass(nextRow, nextCol, grid);
            }
        }
    }
    private static bool isLandMass(char[][] grid, int nextRow, int nextCol)
    {
        if (nextRow >= 0 && grid.Length > nextRow && nextCol >= 0 && grid[0].Length > nextCol)
        {
            return grid[nextRow][nextCol] == '1';
        }
        else return false;
    }
    private string getLandIndentifier(int row, int col)
    {
        return $"{row},{col}";
    }
    private void dfs(int i)
    {
        foreach (var neighbour in graph[i])
        {
            if (!seen[neighbour])
            {
                seen[neighbour] = true;
                dfs(neighbour);
            }
        }
    }
    private void dfsStack(int start)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(start);
        while (stack.Count > 0)
        {
            int node = stack.Pop();
            foreach (int neighbor in graph[node])
            {
                if (!seen[neighbor])
                {
                    seen[neighbor] = true;
                    stack.Push(neighbor);
                }
            }
        }
    }
}