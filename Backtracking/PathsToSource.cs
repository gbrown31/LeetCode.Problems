namespace Backtracking;

public class PathsToSource
{
    private int n = 0;
    private int[][] graph;
    private IList<IList<int>> results;

    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        this.n = graph.Length;
        this.graph = graph;
        results = new List<IList<int>>();
        
        LinkedList<int> path = new LinkedList<int>();
        path.AddLast(0);

        nodeBacktrack(path, 0);

        return results;
    }

    private void nodeBacktrack(LinkedList<int> path, int currNode)
    {
        if (currNode == n - 1)
        {
            results.Add(new List<int>(path));
            return;
        }

        for (int i = 0; i < graph[currNode].Length; i++)
        {
            int nextNode = graph[currNode][i];
            path.AddLast(nextNode);
            nodeBacktrack(path, nextNode);
            path.RemoveLast();
        }
    }
}