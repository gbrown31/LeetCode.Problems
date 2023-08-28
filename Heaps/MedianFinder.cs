namespace Heaps;

public class MedianFinder 
{
    private PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
    private PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(new MaxHeapComparer());
    public MedianFinder() {
        
    }
    
    public void AddNum(int num)
    {
        // add number to max heap
        maxHeap.Enqueue(num, num);
        
        // remove smallest number from max heap
        int maxHeapSmallest = maxHeap.Dequeue();

        // put the small number from the max heap onto the min heap
        minHeap.Enqueue(maxHeapSmallest, maxHeapSmallest);
        
        // if min heap has more than max heap then we'll favour the max heap to contain 
        // our larger set of values
        if (minHeap.Count > maxHeap.Count)
        {
            // take largest element from the min heap
            int minHeapLargestElement = minHeap.Dequeue();
            
            // add to the max heap
            maxHeap.Enqueue(minHeapLargestElement, minHeapLargestElement);
        }
    }
    
    public double FindMedian()
    {
        // if max has more than min then take the last element from max
        if (maxHeap.Count > minHeap.Count)
        {
            return maxHeap.Peek();
        }
        // else the heaps are event are we'll calculate the median
        return (minHeap.Peek() + maxHeap.Peek()) / 2.0;
    }

    private class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
}