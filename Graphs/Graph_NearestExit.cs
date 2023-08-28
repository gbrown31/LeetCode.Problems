namespace Graphs;

public class Graph_NearestExit
{
    private class Coordinate
    {
        public Coordinate(int row, int col, int steps)
        {
            Row = row;
            Col = col;
            Steps = steps;
        }
        public int Row { get; }
        public int Col { get; }

        public int Steps { get; }
        // steps?

        public string getCoordinateName()
        {
            return $"{Row},{Col}";
        }
    }

    private int[] restrictedExits;
    public int NearestExit(char[][] maze, int[] entrance)
    {
        int[][] directions = new int[][] {new int[] {0, 1}, new int[] {0, -1}, new int[] {1, 0}, new int[] {-1, 0}};
        HashSet<string> visitedCoordinates = new HashSet<string>();
        Queue<Coordinate> queue = new Queue<Coordinate>();
        // grid of rows m and colmns n
        // grid contains either . or +
        // . at a border is an exit

        // no need to loop the grid
        // start at coordinates given
        // record as being visited
        restrictedExits = entrance;
        int row = entrance[0],
            col = entrance[1];
        var coOrd = new Coordinate(row, col, 0);
        queue.Enqueue(coOrd);
        

        while (queue.Count > 0)
        {
            Coordinate currentCoOrd = queue.Dequeue();

            if (IsExit(maze, currentCoOrd.Row, currentCoOrd.Col))
            {
                return currentCoOrd.Steps;
            }
            
            // exit case would be row,col value == . where 
            // row = m-1 or col=n-1
            
            //record visiting the node
            visitedCoordinates.Add(coOrd.getCoordinateName());
            int currentStep = currentCoOrd.Steps + 1;
            // bfs using queue for all 4 directions
            foreach (int[] direction in directions)
            {
                int rowMove = direction[0],
                    colMove = direction[1];
                
                Coordinate newDirection = new Coordinate(
                    currentCoOrd.Row + rowMove,
                    currentCoOrd.Col + colMove,
                    currentStep
                );
                // only enque valid directions
                if (CanMoveInMaze(maze, newDirection.Row, newDirection.Col) 
                    && !visitedCoordinates.Contains(newDirection.getCoordinateName()))
                {
                    if (IsExit(maze, newDirection.Row, newDirection.Col))
                    {
                        return newDirection.Steps;
                    }
                    queue.Enqueue(newDirection);
                }
            }
        }

        return -1;
    }

    private bool IsExit(char[][] maze, int row, int col)
    {
        if (row == restrictedExits[0] && col == restrictedExits[1])
        {
            return false;
        }
        
        if (row == maze.Length - 1 || row == 0 || col == maze[0].Length-1 || col==0)
        {
            if (maze[row][col] == '.')
            {
                return true;
            }
        }
        return false;
    }

    private bool CanMoveInMaze(char[][] maze, int row, int col)
    {
        if (row >= 0 && row < maze.Length && col >= 0 && col < maze[0].Length && maze[row][col] == '.')
        {
            return true;
        }
        else return false;
    }
}