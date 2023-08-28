namespace Heaps;

public class Heaps_MinStones
{
    private PriorityQueue<int, int> heapOfStones = new PriorityQueue<int, int>(new MaxHeapComparer());
    public int MinStoneSum(int[] piles, int k)
    {
        // have a pile of stones in piles
        // need to remove Math.Floor(pileItem/2) from the pile
         // suppose we find pileItem, remove it from the array, do the calculation then add it back to the pile?
         
        // find the minimum number of possible stones after K operations
        // we need to know the max no of stones in the piles at each time
        // priority queue max heap?
        
        // add all the stones to the heap
        for (int i = 0; i < piles.Length; i++)
        {
            heapOfStones.Enqueue(piles[i], piles[i]);
        }
        
        // for i < k find the top element in the heap
        for (int i = 0; i < k; i++)
        {
            // remove it and do calculation
            int biggestPileOfStones = heapOfStones.Dequeue();
            int remainingStones = Convert.ToInt32(Math.Floor((decimal) biggestPileOfStones / 2));

            biggestPileOfStones -= remainingStones;

            // add new item to the heap
            heapOfStones.Enqueue(biggestPileOfStones, biggestPileOfStones);
        }
        // pop all items from the heap and return
        int sumOfStones = 0;
        while (heapOfStones.Count > 0)
        {
            sumOfStones += heapOfStones.Dequeue();
        }

        return sumOfStones;
    }
    internal class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
}