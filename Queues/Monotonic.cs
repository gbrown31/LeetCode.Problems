using System.IO.Pipes;
using LinkedLists;

namespace Queues;

public class Monotonic
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] answer = new int [temperatures.Length];
        Stack<int> hotterTemp = new Stack<int>();
        for (int i = 0; i < temperatures.Length; i++)
        {
            int todaysTemp = temperatures[i];

            while (hotterTemp.Count > 0 && todaysTemp > temperatures[hotterTemp.Peek()])
            {
                int indexOfColderDay = hotterTemp.Pop();
                answer[indexOfColderDay] = i - indexOfColderDay;
            }
            // push index of the temp
            hotterTemp.Push(i);
        }

        return answer;
    }
    public int[] MaxSlidingWindow(int[] nums, int lengthOfWindow)
    {
        int[] answer = new int[] { };
        LinkedList<int> maxOfSlidingWindows = new LinkedList<int>();
        
        // loop each window
        for (int i = 0; i < nums.Length; i++)
        {
            // within the window check for smaller items and remove them?
            if (maxOfSlidingWindows.Count > 0 && nums[maxOfSlidingWindows.Last.Value] < nums[i])
            {
                maxOfSlidingWindows.RemoveLast();
            }
            
            // add the index to maxOfSliding windows
            maxOfSlidingWindows.AddLast(i);
            
            // if we exceed the limit then remove item from front of the list
            if (maxOfSlidingWindows.First.Value + lengthOfWindow == i)
            {
                maxOfSlidingWindows.RemoveFirst();
            }

            // once loop is at the end of the window get value from nums by index
            if (i >= lengthOfWindow - 1)
            {
                int indexOfMaxWithinWindow = maxOfSlidingWindows.First.Value;
                answer[(i - indexOfMaxWithinWindow) + 1] = nums[indexOfMaxWithinWindow];
            }
        }
        return answer;
    }
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        int[] answer = new int[nums1.Length];

        int[][] directions = new int[][] { new[] { 1, 0 }, new[] { -1, 0 }, new[] { 0, 1 }, new[] { 0, -1 } };
        bool[,] seen = new bool[2, 2];
        // nums 1 is a subset of nums 2
        // that is all values in nums 1 exist in nums 2

        Stack<int> stack = new Stack<int>();
        Dictionary<int, int> greaterValues = new Dictionary<int, int>();

        LinkedList<int> first = new LinkedList<int>();
        
        // foreach value in nums2 have a data structure that contains the index of each item and it's next biggest item
        // how to do this?!
        for (int i = 0; i < nums2.Length; i++)
        {
            while (stack.Count > 0 && nums2[i] > stack.Peek())
            {
                greaterValues.Add(stack.Pop(), nums2[i]);
            }
            stack.Push(nums2[i]);
        }

        while (stack.Count > 0)
        {
            greaterValues.Add(stack.Pop(), -1);
        }
        
        // foreach value in nums2 read value and push to answer
        for (int i = 0; i < nums1.Length; i++)
        {
            answer[i] = greaterValues[nums1[i]];
        }
        return answer;
    }
    public int LongestSubarray(int[] nums, int limit)
    {
        int answer = 0;
        Stack<int> a = new Stack<int>();
        
        for (int i = 0; i < nums.Length; i++)
        {
            //while(a.Count>0 && a.Peek())
        }

        return answer;
    }
    
    public int[] NextLargerNodes(ListNode head)
    {
        Dictionary<int, int> linkedListMap = new Dictionary<int, int>();
        Stack<int> indexes = new Stack<int>();
        Dictionary<int, int> greaterValue = new Dictionary<int, int>();
        ListNode current = head;
        // loop the nodes of the linkedList
        int i = 0;
        while (current != null)
        {
            linkedListMap.Add(i, current.val);

            if (indexes.Count > 0 && current.val > linkedListMap[indexes.Peek()])
            {
                greaterValue.Add(indexes.Pop(), i);
            }

            indexes.Push(i);
            i++;
            current = current.next;
        }

        while (indexes.Count > 0)
        {
            greaterValue.Add(linkedListMap[indexes.Pop()], 0);
        }

        int[] answer = new int[greaterValue.Count];
        int pointer = 0;
        foreach (var keyValue in greaterValue)
        {
            answer[pointer] = keyValue.Value;
            pointer++;
        }

        return answer;
        // create hashset of value and next greatest value
        // loop head.next
        // if the next value is greater than top of stack, pop and add to diction<int, int> where ints are indexes
        // push index onto onto the stack

        // loop stack and pop into dictionary<int, int> setting second index to be 0;

        // foreach key in the dictionary find the value for the second index and add to arrya
        // can I store the index/value of the nodes in hashset?

        //return new int[] { };
    }
}