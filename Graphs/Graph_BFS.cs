namespace Graphs;

public class Graph_BFS
{
    class State
    {
        public int row;
        public int col;
        public int steps;

        public State(int row, int col, int steps)
        {
            this.row = row;
            this.col = col;
            this.steps = steps;
        }
    }

    int n;

    private int[][] directions = new int[][]
    {
        new int[] {-1, -1}, new int[] {-1, 0}, new int[] {-1, 1}, new int[] {0, -1}, new int[] {0, 1},
        new int[] {1, -1}, new int[] {1, 0}, new int[] {1, 1}
    };

    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        if (grid[0][0] == 1)
        {
            return -1;
        }

        n = grid.Length;
        // more convenient to use a 2d array instead of a set for seen
        bool[][] seen = new bool[][] { };
        seen[0][0] = true;
        Queue<State> queue = new Queue<State>();
        queue.Enqueue(new State(0, 0, 1)); // row, col, steps

        while (queue.Count > 0)
        {
            State state = queue.Dequeue();
            int row = state.row, col = state.col, steps = state.steps;
            if (row == n - 1 && col == n - 1)
            {
                return steps;
            }

            foreach (int[] direction in directions)
            {
                int nextRow = row + direction[0],
                    nextCol = col + direction[1];
                
                if (valid(nextRow, nextCol, grid) && !seen[nextRow][nextCol])
                {
                    seen[nextRow][nextCol] = true;
                    queue.Enqueue(new State(nextRow, nextCol, steps + 1));
                }
            }
        }

        return -1;
    }
    public bool valid(int row, int col, int[][] grid) {
        return 0 <= row && row < n && 0 <= col && col < n && grid[row][col] == 0;
    }
}