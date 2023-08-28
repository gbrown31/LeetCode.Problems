namespace BinarySearch;

public class MinimumDivisor
{
    private int Threshold = 0;
    public int SmallestDivisor(int[] nums, int threshold)
    {
        // for the nums, find the minimum divisor that can be used to divide
        // each value and sum the result, keeping it within threshold
        Threshold = threshold;
        int left = 0,
            right = Convert.ToInt32(Math.Pow(10, 6));
        
        // use binary search to find values
        // - call check method to ensure all division sum is within threshold
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (checkArrayDivisonWithLimit(mid, nums))
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }

    private bool checkArrayDivisonWithLimit(int divisor, int[] nums)
    {
        double runningTotal = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            runningTotal = Math.Ceiling(runningTotal);
            runningTotal += nums[i] / (double) divisor;
        }
        return runningTotal <= Threshold;
    }
}