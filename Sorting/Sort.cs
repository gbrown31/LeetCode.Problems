namespace Sorting;

public class Sort
{
    /// <summary>
    /// Uses divide and conquer to break the array into smaller and smaller left and right halves.
    /// Create temp arrays to compare and recreate the array. Remaining elements then added. 
    /// </summary>
    /// <tag>divide, conquer, recursion, two pointer,temp storage</tag>
    /// <bigO name="space">O(n)</bigO>
    /// <bigO name="time">O(log(n))</bigO>
    public int[] MergeSort(int[] nums)
    {
        mergeSort(nums, 0, nums.Length - 1);
        return nums;
    }
    #region Merge Sort
    private void mergeSort(int[] nums, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            mergeSort(nums, left, mid);
            mergeSort(nums, mid + 1, right);

            merge(nums, left, mid, right);
        }
    }
    private void merge(int[] nums, int left, int mid, int right)
    {
        // get the length of arrays to be merged
        int lengthOfFirstArray = mid - left + 1,
            lengthOfSecondArray = right - mid;
        
        // Create temp arrays
        int[] leftArray = new int[lengthOfFirstArray],
            rightArray = new int[lengthOfSecondArray];

        // create pointers
        int i = 0,
            j = 0;

        // copy data to the temp arrays
        for (i = 0; i < lengthOfFirstArray; i++)
        {
            leftArray[i] = nums[left + i];
        }
        for (j = 0; j < lengthOfSecondArray; j++)
        {
            rightArray[j] = nums[mid + 1 + j];
        }
        
        //reset pointers
        i = 0;
        j = 0;
        int pointer = left;
        // merge the temp arrays
        while (i < lengthOfFirstArray && j < lengthOfSecondArray)
        {
            // left array smaller
            if (leftArray[i] <= rightArray[j])
            {
                // set nums k to be smaller item
                nums[pointer] = leftArray[i];
                // increment i within first array bounds
                i++;
                
            }
            else
            {
                // right array must be smaller
                // set nums k to be right array
                nums[pointer] = rightArray[j];
                // increment j within second array bounds
                j++;
            }

            // increment k to next position in original array
            pointer++;
        }

        // if i has not reached end of the first array
        // copy elements
        while (i < lengthOfFirstArray)
        {
            nums[pointer] = leftArray[i];
            i++;
            pointer++;
        }

        while (j < lengthOfSecondArray)
        {
            nums[pointer] = rightArray[j];
            j++;
            pointer++;
        }
    }
    #endregion

    /// <summary>
    /// Uses divide and conquer. Finds a partition to compare items to then organises the array into 2 halves.
    /// Each half is then partitioned and sorted iteratively.
    /// </summary>
    /// <tag>divide, conquer, recursion, partition, swap</tag>
    /// <bigO name="space">O(log(n))</bigO>
    /// <bigO name="time">O(n log(n))</bigO>
    public int[] QuickSort(int[] nums)
    {
        quicksort(nums, 0, nums.Length - 1);
        return nums;
    }
    #region Quick Sort
    private void quicksort(int[] nums, int low, int high)
    {
        if (low < high)
        {
            int partition = customPartition(nums, low, high);
            quicksort(nums, low, partition - 1);
            quicksort(nums, partition + 1, high);
        }
    }

    // Quick sort relies on the partition to partially sort the array
    // as best it can in a single pass by selecting a pivot between low and high
    // as the range becomes smaller the sort becomes more accurate
    private int customPartition(int[] nums, int low, int high)
    {
        // pick a element to pivot on
        // lets go with last
        int pivot = nums[high];

        //need to keep track of which elements we are swapping
        // start at -1, outside the array
        int i = (low - 1);

        for (int j = low; j < high; j++)
        {
            // check if the current item j is less than the pivot
            if (nums[j] < pivot)
            {
                // move j to position i in the array
                i++;
                swap(nums, i, j);
            }
        }
        
        // at the end of the iteration the only element that couldn't move was the pivot
        // place the pivot at the next index of i
        swap(nums, i + 1, high);
        
        // return the next index to be considered as the pivot
        return i + 1;
    }

    
    // example 1 [13, 5, 15]
    private int getPartition(int[] nums, int low, int high)
    {
        // first pass low is 0 and high is index of the last element
        // setting the pivot to last element
        int pivot = nums[high];
        
        // set index i to low - 1, which would be -1 on first pass
        int i = (low - 1);

        // loop over all elements for index j
        for (int j = low; j < high; j++)
        {
            // if the item at index j is less than the pivot then swap
            // 13 is less than pivot
            // 5 is less than 15
            if (nums[j] < pivot)
            {
                // swapping 13 with 13
                // swapping 5 with 5
                i++;
                swap(nums, i, j);
            }
        }

        // swap 15 with 15
        // i should be the last index we swapped, as high index was the pivot
        // place this value in the next index after i as no value should be left that is lower than it
        swap(nums, i + 1, high);
        return i + 1;
    }
    #endregion

    /// <summary>
    /// Compares each element with the previous elements to find the earliest place in the array to
    /// insert the element 
    /// </summary>
    /// <tag>two loops, find minimum, swap</tag>
    /// <bigO name="space">O(1)</bigO>
    /// <bigO name="time">O(n power2)</bigO>
    public int[] InsertionSort(int[] nums)
    {
        if (nums == null)
        {
            return new int[] { };
        }

        // [15, 5, 13]
        // compare each element with the previous element
        for (int i = 1; i < nums.Length; i++)
        {
            // store temp value of current index
            int value = nums[i];
            int j = i - 1;
            while (j >= 0 && value < nums[j])
            {
                // set current index to previous
                nums[j + 1] = nums[j];
                // move j backwards towards the beginning of the array until it reaches
                // correct location
                j--;
            }

            // as index j was originally bigger than i store the temp
            // value in the next index
            nums[j + 1] = value;
        }

        return nums;
    }

    /// <summary>
    /// For each element, find the smallest index by iterating over the array again and then swapping elements
    /// </summary>
    /// <tag>two loops, find minimum, swap</tag>
    /// <bigO name="space">O(1)</bigO>
    /// <bigO name="time">O(n power2)</bigO>
    public int[] SelectionSort(int[] nums)
    {
        // loop every index in the array
        for (int i = 0; i < nums.Length; i++)
        {
            // find the smallest index
            int minIndex = i;
            for (int j = i + 1; j < nums.Length; j++)
            {
                // select the smallest index from the possible numbers
                if (nums[j] < nums[minIndex])
                {
                    minIndex = j;
                }
            }

            swap(nums, minIndex, i);
        }

        return nums;
    }

    /// <summary>
    /// For each element, iterate over the array comparing element to the next element and swapping accordingly
    /// </summary>
    /// <tag>two loops, find minimum, swap</tag>
    /// <bigO name="space">O(1)</bigO>
    /// <bigO name="time">O(n power2)</bigO>
    public int[] BubbleSort(int[] nums)
    {
        // iterate over every element
        for (int i = 0; i < nums.Length; i++)
        {
            bool swapped = false;
            for (int j = 0; j < nums.Length - i; j++)
            {
                int nextIndex = j + 1;
                if (nextIndex < nums.Length && nums[j] > nums[nextIndex])
                {
                    swap(nums, j, j + 1);
                    swapped = true;
                }
            }

            // if nothing has been swapped then it must be in order
            if (!swapped)
            {
                break;
            }
        }

        return nums;
    }

    private void swap(int[] nums, int minIndex, int indexToMove)
    {
        int temp = nums[minIndex];
        nums[minIndex] = nums[indexToMove];
        nums[indexToMove] = temp;
    }
}