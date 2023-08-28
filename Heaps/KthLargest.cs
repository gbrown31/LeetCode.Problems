namespace Heaps;

public class KthLargest
{
    private readonly int k = 0;
    private PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(new MaxHeapComparer());
    public KthLargest(int k, int[] nums)
    {
        this.k = k;
        // looking for K largest element so we potentially need a max heap of ints
        // use priority queue?
        
        // add seed data to the heap
        for (int i = 0; i < nums.Length; i++)
        {
            maxHeap.Enqueue(nums[i], nums[i]);
        }
        
    }

    public int Add(int val)
    {
        // add the value to max heap and find the element K in the heap
        maxHeap.Enqueue(val, val);
        
        // pop K - 1 items from the queue and store somewhere, an array?
        // find the K element and return;
        int kValue = 0;
        int[] valuesGreaterThanK = new int[k - 1];
        for (int i = 0; i < valuesGreaterThanK.Length; i++)
        {
            valuesGreaterThanK[i] = maxHeap.Dequeue();
        }
        kValue = maxHeap.Peek();
        
        // add the values back to the heap
        for (int i = 0; i < valuesGreaterThanK.Length; i++)
        {
            maxHeap.Enqueue(valuesGreaterThanK[i], valuesGreaterThanK[i]);
        }

        return kValue;
    }
}

internal class MaxHeapComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return y.CompareTo(x);
    }
}