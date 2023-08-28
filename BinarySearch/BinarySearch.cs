using Microsoft.VisualBasic;

namespace BinarySearch;

public class BinarySearch
{
    public int FindTarget(int[] nums, int target)
    {
        int targetIndex = -1;
        // set left index to start, set right index to end
        int left = 0;
        int right = nums.Length - 1;

        // loop while left is not more than right index
        while (left <= right)
        {
            // find mid point of the array
            int mid = left + (right - left) / 2;

            // if target found then return
            if (nums[mid] == target)
            {
                // do something
                targetIndex = mid;
                return mid;
            }

            // if the value in the mid is greater than target then move search to the first index before mid
            if (nums[mid] > target)
            {
                right = mid - 1;
            }
            // else move the left pointer to one element after the mid
            else
            {
                left = mid + 1;
            }
        }

        // target is not in arr, but left is at the insertion point
        return targetIndex;
    }
    public bool SearchMatrix(int[][] matrix, int target)
    {
        bool targetFound = false;
        // find number of rows, columns and items
        int m = matrix.Length,
            n = matrix[0].Length,
            totalIndexes = m * n;

        // set left index to 0, set right index to furthest index
        int left = 0,
            right = totalIndexes - 1;

        // loop while left is not greater than right
        while (left <= right)
        {
            // find mid of the range
            int mid = left + (right - left) / 2;
            int row = mid / n;
            int col = mid % n;

            // if mid == target
            //  - return true
            int midValue = matrix[row][col];
            if (midValue == target)
            {
                return true;
            }

            // if target is greater than mid value then shift left pointer to next element after mid
            if (midValue < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return targetFound;
    }
    public int SearchInsert(int[] nums, int target)
    {
        // find index of the target
        // or return index at which target should be inserted

        // set left index to 0
        // set right index to length -1
        int left = 0,
            right = nums.Length - 1;

        // while left <= right
        while (left <= right)
        {
            // find mid point, right -left /2
            // get value at mid pointer
            int mid = left + (right - left) / 2;

            // if value matches target then return index mid
            if (nums[mid] == target)
            {
                return mid;
            }

            // if the value in the mid is greater than target then move search to the first index before mid
            if (nums[mid] > target)
            {
                right = mid - 1;
            }
            // else move the left pointer to one element after the mid
            else
            {
                left = mid + 1;
            }
        }

        // if target not found then return left or right pointer?
        return left;
    }
    public int[] AnswerQueries(int[] nums, int[] queries)
    {
        // binary search requires a sorted array!!
        Array.Sort(nums);
        int[] answer = new int[queries.Length];
        // for each value (i) in queries find the largest subsequence in nums (j) with a 
        // sum less than i

        // calculate sum of indexes array (prefix sum)
        int[] prefixSum = new int[nums.Length];
        prefixSum[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + nums[i];
        }

        for (int i = 0; i < queries.Length; i++)
        {
            answer[i] = doBinarySearch(prefixSum, queries[i]);
        }

        return answer;
    }
    private int doBinarySearch(int[] nums, int target)
    {
        int answer = 0;
        // set left index to 0
        // set right index to nums.length -1
        int left = 0,
            right = nums.Length - 1;

        // while left > right
        // find mid
        while (left < right)
        {
            // get value for mid
            // adjust pointers
            int mid = left + (right - left) / 2;
            if (nums[mid] == target)
            {
                return mid + 1;
            }
            if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else left = mid + 1;
        }
        
        // if the index at left is still bigger than target then it can't be one index more
        return nums[left] > target ? left : left + 1;
    }
    
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        // sort the 2nd array into ascending order
        Array.Sort(potions);
        int[] ans = new int[spells.Length];
        int m = potions.Length;
        
        // positions x * spell Y > success == success
        // success / Y  > x == success
        
        // for each index in spell
        // search potions for a suitable pair
        for (int i = 0; i < spells.Length; i++) {
            // as potions has been sorted then j is the final index of all valid values
            int j = binarySearch(potions, success / (double) spells[i]);
            // can calculate the number of valid potions by 
            ans[i] = m - j;
        }
        
        return ans;
    }
    private int binarySearch(int[] arr, double target) {
        int left = 0;
        int right = arr.Length - 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] < target) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        
        return left;
    }
    public int MaxDistance(int[] nums1, int[] nums2)
    {
        // if I sort nums2 then I can search it for values that are less than or equal to index i
        // i can then loop over nums1 and find the target index where it matches or where it is less than target
        int maxDistance = 0;
        for (int i = 0; i < nums1.Length; i++)
        {
            // why am I doing this binary search?
            int j = GetIndexOfTarget(nums2, nums1[i]);
            while (j >= 0)
            {
                if (i <= j && nums1[i] <= nums2[j])
                {
                    // check each index of j in the array as all numbers
                    int distance = j - i;
                    maxDistance = Math.Max(maxDistance, distance);
                    
                }
                j--;
            }
        }

        return maxDistance;
    }
    private int GetIndexOfTarget(int[] nums, int target)
    {
        int answer = 0;
        // set left index to 0
        // set right index to nums.length -1
        int left = 0,
            right = nums.Length - 1;

        // while left > right
        // find mid
        while (left < right)
        {
            // get value for mid
            // adjust pointers
            int mid = left + (right - left) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            // array is in descending order
            if (nums[mid] > target)
            {
                // right heads towards left index
                left = mid + 1;
            }
            // left heads towards right index
            else right = mid - 1;
        }

        if (nums[left] > target)
        {
            return left;
        }
        else if(left == nums.Length-1)
        {
            return left;
        }
        else
        {
            return left + 1;
        }

        //return nums[left] > target ? left : left + 1;;
    }
}