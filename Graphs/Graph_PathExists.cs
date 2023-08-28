namespace Graphs;

public class Graph_PathExists
{
    private Dictionary<int, List<int>> citiesAndNeighbours = new Dictionary<int, List<int>>();
    private HashSet<int> citiesVisited = new HashSet<int>();
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        // n is number of nodes/vertices
        // edges are the bidirectional joins between the vertices
        // source is the starting point, destination is the end point
        // return true if destination can be reach from start by traversing the edges

        if (n == 0)
        {
            return false;
        }
        if (n ==1 && edges.Length == 0 || source == destination)
        {
            return true;
        }
        
        // build list of nodes and joins
        for (int i = 0; i < n; i++)
        {
            citiesAndNeighbours.Add(i, new List<int>());
        }

        foreach (int[] connection in edges)
        {
            int city1 = connection[0],
                city2 = connection[1];
            
            citiesAndNeighbours[city1].Add(city2);
            citiesAndNeighbours[city2].Add(city1);
            // do we need to record the names of the connections?
        }

        // depth first search from source node all levels to attempt to find the destination
        // need to track visited nodes
        return findIfDestinationCanBeReach(source, destination);
    }
    private bool findIfDestinationCanBeReach(int source, int destination)
    {
        bool destinationFound = false;
        citiesVisited.Add(source);
        foreach (int neighbour in citiesAndNeighbours[source])
        {
            if (!citiesVisited.Contains(neighbour))
            {
                if (neighbour == destination)
                {
                    return true;
                }

                destinationFound = findIfDestinationCanBeReach(neighbour, destination);
                if (destinationFound)
                {
                    return destinationFound;
                }

                citiesVisited.Add(neighbour);
            }
        }

        return false;
    }
}