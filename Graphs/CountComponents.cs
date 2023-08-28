namespace Graphs;

public class CountComponents
{
     public int CountComponents2(int n, int[][] edges) 
    {
        // give n nodes and edges 
        // find how many components are in the graph
        
        // create a dictionary of nodes and neighbours
        Dictionary<int, HashSet<int>> nodes = new Dictionary<int, HashSet<int>>();
        for (int i = 0; i < n; i++)
        {
            nodes.Add(i, new HashSet<int>());
        }
        // iterate over edges and create relationships
        // relationships are undirected
        for(int i=0; i<edges.Length; i++)
        {
            int node1 = edges[i][0],
                node2 = edges[i][1];
            
            nodes[node1].Add(node2);
            nodes[node2].Add(node1);
        }
        Console.WriteLine($"nodes {nodes.Count}");
        
        // search the nodes and all the neighbours
        // search for what?
        // record when we've visited a node
        // if the node count at the end of each iteration doesn't equal n then
        // it is a separate component of the graph
        Stack<int> stack = new Stack<int>();
        bool[] seen = new bool[n];
        int components = 0;
        
        for(int i = 0; i<nodes.Count; i++)
        {
            if(!seen[i])
            {
                Console.WriteLine($"Node to process {i}");
                stack.Push(i);
                components++;
            }
            
            Console.WriteLine($"stack.Count {stack.Count}");
            while(stack.Count > 0)
            {
                int node = stack.Pop();
                Console.WriteLine($"Processing node {i}");
                foreach(int neighbour in nodes[node])
                {
                    Console.WriteLine($"Processing neighbour {neighbour} in node {i}");
                    if(!seen[neighbour])
                    {
                        stack.Push(neighbour);
                        seen[neighbour] = true;
                    }
                }                
            }
            
            seen[i] = true;
        }

        for (int i = 0; i < seen.Length; i++)
        {
            if (!seen[i])
            {
                components++;
            }
        }
        return components;
    }
}