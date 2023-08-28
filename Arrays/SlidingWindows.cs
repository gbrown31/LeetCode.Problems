namespace Arrays;

public class SlidingWindows
{
    /// <summary>
    /// 
    /// </summary>
    /// <tag>while loop, two pointers, array, math</tag>
    /// <bigO name="space">O(1)</bigO>
    /// <bigO name="time">O(n)</bigO>
    public int GetMaxArea(int[] height)
    {
        int left = 0,
            right = height.Length - 1,
            maxVolume = 0;

        while (left < right)
        {
            int containerHeight = Math.Min(height[left], height[right]);
            int containerWidth = right - left;
            int containerVolume = containerHeight * containerWidth;

            maxVolume = Math.Max(maxVolume, containerVolume);

            if (left < right)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxVolume;
    }
    
    public long GetZeroFilledSubarray(int[] nums)
    {
        long subArrays = 0; 
        int consecutiveZero = 0;
        int left = 0;
        for (int right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 0)
            {
                consecutiveZero++;
                // calculate no of sub arrays at pointer
                // right - 
                subArrays += consecutiveZero;
            }

            // if we find a non zero number then bring left pointer up
            if (nums[right] != 0)
            {
                consecutiveZero = 0;
                while (left < right)
                {
                    left++;
                }
            }
        }
        return subArrays;
    }
    
    public long GetNoOfZeroes(int[] nums)
    {
        long noOfZeroes = 0; 
        int consecutiveZero = 0;
        int left = 0;
        for (int right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 0)
            {
                consecutiveZero++;
                // calculate no of sub arrays at pointer
                // right - 
                noOfZeroes++;
            }

            // if we find a non zero number then bring left pointer up
            if (nums[right] != 0)
            {
                consecutiveZero = 0;
                while (left < right)
                {
                    left++;
                }
            }
        }
        return noOfZeroes;
    }
    
    /// <summary>
    /// Get the maximum consecutive 1s from the array by flipping at most
    /// noInvalidCharactersAllowed 0s
    /// </summary>
    /// <tag>while loop, sliding windows, two pointers, array, math</tag>
    /// <bigO name="space">O(1)</bigO>
    /// <bigO name="time">O(n)</bigO>
    public int GetMaxConsecutiveOnes(int[] nums, int noInvalidCharactersAllowed)
    {
        int longestSequence = 0;
        // create 2 pointers, left and right
        // start at 0 looping right array
        int left = 0;
        int invalidCharacterCount = 0;
        for (int right = 0; right < nums.Length; right++)
        {
            if (nums[right] != 1)
            {
                invalidCharacterCount++;
            }

            while (invalidCharacterCount > noInvalidCharactersAllowed)
            {
                if (nums[left] == 0)
                {
                    invalidCharacterCount--;
                }
                left++;
            }

            longestSequence = Math.Max(longestSequence, (right - left) + 1);
        }
        return longestSequence;
    }
}