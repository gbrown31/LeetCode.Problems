namespace Sorting;

public class MergeSort
{

    public int[] Sort(int[] nums)
    {
        // call merge sort on the array, passing in left and right index
        mergeSort(nums, 0, nums.Length - 1);
        return nums;
    }

    private void mergeSort(int[] nums, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            // recursively call merge sort to find smallest sub arrays to merge
            mergeSort(nums, left, mid);
            mergeSort(nums, mid + 1, right);

            // call merge to to put the sub arrays into the correct order
            merge(nums, left, mid, right);
        }
    }

    /// <summary>
    /// merge the array at indexes left to right by creating temp data to hold
    /// the array values. use 2 pointers, i and j to find the smaller of the values to
    /// add to original array at left point
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="left"></param>
    /// <param name="mid"></param>
    /// <param name="right"></param>
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

        i = 0;
        j = 0;
        int pointer = left;
        while (i < lengthOfFirstArray && j < lengthOfSecondArray)
        {
            // find smaller
            if (leftArray[i] < rightArray[j])
            {
                // add to pointer index
                nums[pointer] = leftArray[i];
                i++;
            }
            else
            {
                nums[pointer] = rightArray[j];
                j++;
            }
            //increment pointer
            pointer++;
        }

        // add remaining left nodes
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
}