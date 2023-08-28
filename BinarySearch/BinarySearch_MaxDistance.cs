namespace BinarySearch;

public class BinarySearch_MaxDistance
{
    public int MaxDistance(int[] nums1, int[] nums2)
    {
        // for each index i in nums1 find the index j in nums2
        // where i & j are a valid pair
        int maxDistance = 0;
        for (int i = 0; i < nums1.Length; i++)
        {
            int target = nums1[i];
            int j = findIndex(nums2, target) - 1;
            
            // j is where the target could fit
            // if the numbers are going in reverse order then j-1 must be bigger than i?

            // j must be the biggest index of nums2 that is compatible
            if (i <= j && nums1[i] <= nums2[j])
            {
                // valid pair logic in here
                // compare maxDistance to currentDistance between pairs
                maxDistance = Math.Max(maxDistance, j - i);
            }
        }

        return maxDistance;
    }

    private int findIndex(int[] nums2, int target)
    {
        // nums2 could be 100, 20, 10, 10, 15
        // target could be 55
        // set left and right index
        // while left <= right (want to check every index) 
        int left = 0,
            right = nums2.Length - 1;
        while (left <= right)
        {
            // left is 0 and right is 4
            // find mid value left+(right-left)/2
            int mid = left + (right - left) / 2;

            // mid is 2 (10), target is 55
            // search in left half of the array
            // left is 0 and right would be 2

            // mid could be 1 (20), target is 55
            // left is 0 and right would be 1

            // mid could be 0 (100), target is 55
            // nums2 is greater than target
            // left is 1 and right would be 1
            if (nums2[mid] < target)
            {
                right = mid - 1;
            }
            else
            {
                // nums2[mid] < target
                // search in right half of the array
                left = mid + 1;
            }
        }

        return left;
    }
}