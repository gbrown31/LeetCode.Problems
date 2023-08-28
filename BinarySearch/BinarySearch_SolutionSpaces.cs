using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace BinarySearch;

public class BinarySearch_SolutionSpaces
{
    private int timeLimit = 0;
    public int MinEatingSpeed(int[] piles, int h)
    {
        // what is the minimum speed at which each pile can be eaten that is also within h time limit
        // only 1 pile can be eaten from at a time, so items remaining in the pile will remain there for next hour
        
        // this creates a problem space from 0 the max(piles.Length)
        // create indexes for left and right
        timeLimit = h;
        int left = 0,
            right = 0;
        
        for (int i = 0; i < piles.Length; i++)
        {
            right = Math.Max(right, piles[i]);
        }

        // want to search every index for a value
        while (left <= right)
        {
            // find mid,
            int mid = left + (right - left) / 2;
            // use binary search to work out which value is the minimum
            //  - use a check method
            //      -- the check method will calculate based on the value of the index from binary search
            //      -- how long it would take to eat all the piles
            //      -- if it is too long then the left pointer moves
            //      -- if it is possible then check within the next search frame
            
            
            // run check
            // adjust pointers
            if (canAllPilesBeEaten(mid, piles))
            {
                // if all piles can be eaten then shift pointers to be smaller
                right = mid - 1;
            }
            else
            {
                // if all piles can not be eaten then shift pointers to be greater
                left = mid + 1;
            }
        }

        return left;
    }
    private bool canAllPilesBeEaten(int eatingSpeed, int[] piles)
    {
        decimal hoursToEatAll = 0;
        if (eatingSpeed == 0)
        {
            return false;
        }
        for (int i = 0; i < piles.Length; i++)
        {
            hoursToEatAll += Math.Ceiling(piles[i] / (decimal) eatingSpeed);
        }

        return hoursToEatAll <= timeLimit;
    }

    int m;
    int n;
    private int[][] directions = new int[][] {new int[] {0, 1}, new int[] {1, 0}, new int[] {0, -1}, new int[] {-1, 0}};
    
    public int MinimumEffortPath(int[][] heights)
    {
        // find the minimum effort required to traverse the undirected graph
        // starting at 0

        // our range of possible efforts are 0 through to max(heights)
        m = heights.Length;
        n = heights[0].Length;
        int left = 0,
            right = 0;

        for (int i = 0; i < heights.Length; i++)
        {
            for (int j = 0; j < heights[i].Length; j++)
            {
                right = Math.Max(right, heights[i][j]);
            }
        }

        // for each of our possible heights we can do a binary search tree to find a value
        // we can then do a DFS for each of the points from our graph, using a stack
        // to traverse the graph
        // search every index
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (canTraverseGraphWithEffort(mid, heights))
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }

    private bool canTraverseGraphWithEffort(int effort, int[][] heights)
    {
        // can we traverse the graph by moving in 4 possible directions without
        // exceeding the effort limit
        bool[,] traversedNodes = new bool[m, n];
        // use a stack
        Stack<XYPair> stack = new Stack<XYPair>();
        // push first node on
        traversedNodes[0, 0] = true;
        XYPair origin = new XYPair(0, 0);
        stack.Push(origin);

        while (stack.Count > 0)
        {
            // while stack is not empty
            // - pop first item, check if exit case
            // - return true if last node
            XYPair node = stack.Pop();
            if (node.X == m - 1 && node.Y == n - 1)
            {
                return true;
            }

            int nodeHeight = heights[node.X][node.Y];
            // for each available direction add a new graph node
            
            foreach (int[] direction in directions)
            {
                int nextRow = node.X + direction[0],
                    nextCol = node.Y + direction[1];

                XYPair nextNode = new XYPair(nextRow, nextCol);
                // need to check if node is a valid direction (within bounds of the array) and can be climbed with effort
                if (valid(nextRow, nextCol) && !traversedNodes[nextRow, nextCol])
                {
                    // can the node be climbed?
                    int nextHeight = heights[nextRow][nextCol];
                    if (Math.Abs(nextHeight - nodeHeight) <= effort)
                    {
                        // we can track which nodes have already been visited so that we don't visit the same one multiple times
                        traversedNodes[nextRow, nextCol] = true;
                        stack.Push(nextNode);
                    }
                }
            }
        }
        return false;
    }
    public bool valid(int row, int col) {
        return 0 <= row && row < m && 0 <= col && col < n;
    }
}

internal class XYPair
{
    public XYPair(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public int Y { get; }
    public int X { get; }
    public bool IsValid => X > -1 && Y > -1;

    public bool WithinBounds(int i, int i1)
    {
        return X < i && Y < i1;
    }
}