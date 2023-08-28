namespace Arrays;

public class FixedWindow
{
    /// <summary>
    /// Find the sub array of length maxSubArrayLength with the maximum average value
    /// </summary>
    /// <tag>sliding windows, array, mat</tag>
    /// <bigO name="space">O(1)</bigO>
    /// <bigO name="time">O(n)</bigO>
    public double FindMaxAverage(int[] nums, int maxSubArrayLength)
    {
        double maxSubArray = 0;
        double currentWindowTotal = 0;
        
        for (int i = 0; i < maxSubArrayLength; i++)
        {
            currentWindowTotal += nums[i];
        }

        maxSubArray = currentWindowTotal;
        for (int i = maxSubArrayLength; i < nums.Length; i++)
        {
            currentWindowTotal += nums[i];
            currentWindowTotal -= nums[i - maxSubArrayLength];

            maxSubArray = Math.Max(maxSubArray, currentWindowTotal);
        }

        return maxSubArray / maxSubArrayLength;
    }
}