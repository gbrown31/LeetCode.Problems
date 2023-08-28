namespace Graphs;

public class FindingHouses
{
    private int[][] Directions = new int[][] { new int[]{1,0},new int[]{-1,0},new int[]{0,-1},new int[]{0,1}};
    public int ShortestDistance(int[][] grid) 
    {
        // from the grid find all the candidate locations
        // a candidate location has a 0 on it
        int n = grid.Length,
         m = grid[0].Length;
        
        HashSet<Land> obstacles = new HashSet<Land>();
        HashSet<Land> buildings = new HashSet<Land>();
        HashSet<Land> plots = new HashSet<Land>();
        
        for(int row=0; row<n; row++)
        {
            for(int cell=0; cell<m; cell++)
            {
                int landType = grid[row][cell];
                switch(landType)
                {
                    case 0:
                        plots.Add(new Land(row, cell));
                        break;
                    case 1:
                        buildings.Add(new Land(row, cell));
                        break;
                    case 2:
                        obstacles.Add(new Land(row, cell));
                        break;
                }
            }
        }
        
        HashSet<string> seen = new HashSet<string>();
        Queue<Land> queue = new Queue<Land>();

        Dictionary<Land, Dictionary<string, Land>> housesFound = new Dictionary<Land, Dictionary<string, Land>>();
        
        // for each candidate location
        foreach(Land location in plots)
        {
            queue.Enqueue(location);
            housesFound.Add(location, new Dictionary<string, Land>());
            
            while(queue.Count > 0)
            {
                Land land = queue.Dequeue();
                
                if(!seen.Contains(land.ToString()))
                {
                    //Console.WriteLine($"processing land {land}");                  

                    foreach(int[] direction in Directions)
                    {
                        //if valid direction
                        int nextX = land.X+direction[0],
                            nextY = land.Y+direction[1];
                        
                        //Console.WriteLine($"checking directions for land {land} at {nextX}, {nextY}");

                        if(nextX >= 0 && nextX < n && nextY >= 0 && nextY < m)
                        {
                            Land neighbour = new Land(nextX, nextY);
                            if(!seen.Contains(neighbour.ToString()))
                            {
                                int landType = grid[neighbour.X][neighbour.Y];

                                if(landType == 1)
                                {
                                    //Console.WriteLine($"found house for land {land} at {neighbour}");
                                    if (!housesFound[location].ContainsKey(neighbour.ToString()))
                                    {
                                        housesFound[location].Add(neighbour.ToString(), neighbour);
                                    }
                                }
                                else if(landType == 0)
                                {
                                    //Console.WriteLine($"adding neighbour for land {land} at {neighbour}");
                                    queue.Enqueue(neighbour);
                                }
                            }
                        }
                    }
                    seen.Add(land.ToString());    
                }                
            }            
        }
        
        bool validCandidateFound = false;
        int minDistance = int.MaxValue;
        Console.WriteLine($"housesFound {housesFound.Count} ");
        foreach(var candidate in housesFound.Where(x=>x.Value.Count>0))
        {
            var houses = candidate.Value.Distinct();
            Console.WriteLine($"candidate houses found {candidate.Value.Count} {buildings.Count}");
            validCandidateFound = true;
            int candidateDistance = 0;
            foreach(var house in candidate.Value.Distinct())
            {
                candidateDistance += getDistance(candidate.Key.X, candidate.Key.Y, house.Value.X, house.Value.Y);
                Console.WriteLine($"candidate houses distance {candidateDistance}");
            }
            minDistance = Math.Min(candidateDistance, minDistance);
            
        }
        
        return validCandidateFound ? minDistance : -1;
    }
    
    private int getDistance(int x1, int y1, int x2, int y2)
    {
        return Math.Abs(x2 - x1) + Math.Abs(y2 - y1);
    }
    private class Land
    {
        public readonly int X;
        public readonly int Y;
        public Land(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        override public string ToString()
        {
            return $"{X},{Y}";
        }
    }
}