namespace Heaps;

public class TopK
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        // for a given array find the top K most frequent elements
        // dictionary<int, int> where first int is the element and second int is the count it appears on the list

        // do I need a dictionary?
        Dictionary<int, int> frequencyOfValue = new Dictionary<int, int>();
        // do I want a min heap?
        PriorityQueue<int, int> heap = new PriorityQueue<int, int>();//(new MaxHeapComparer());
        
        // prepare the data set
        for (int i = 0; i < nums.Length;i++)
        {
            int frequency = 1,
                value = nums[i];

            if (frequencyOfValue.ContainsKey(value))
            {
                frequencyOfValue[value] += frequency;
            }
            else frequencyOfValue.Add(value, frequency);
        }
        // push items onto queue and then remove where count > k
        foreach(var key in frequencyOfValue.Keys)
        {
            heap.Enqueue(key, frequencyOfValue[key]);
            while (heap.Count > k)
            {
                heap.Dequeue();
            }
        }

        int[] result = new int[k];
        for (int i = 0; i < k; i++)
        {
            result[i] = heap.Dequeue();
        }

        return result;
    }
    public int[][] KClosest(int[][] points, int k)
    {
        // from a list of points we can create/imagine a graph of nodes
        // from the chart we know that we can move up, down, left and right
        // for each of the starting points we have, calculate how many "steps" (using directions)
        // that it will take for us to reach the origin node.
        // The origin node is the center of the chart at point 0,0
        
        // the points and the steps have to be stored on a max heap
        //  - manage the heap so that only k points are stored
        
        // dequeue the items
        //  - convert the points to an array of arrays

        return new int[][] { };
    }
}