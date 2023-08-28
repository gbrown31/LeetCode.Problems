namespace Arrays;

public class PrefixSum
{
    public int[] GetPrefixSum(int[] nums)
    {
        int[] prefixSums = new int[nums.Length];

        // first sum is fixed
        prefixSums[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            prefixSums[i] = nums[i] + prefixSums[i - 1];
        }

        return prefixSums;
    }

    public bool[] AnswerQueries(int[] nums, int[][] queries, int limit)
    {
        // return bool array for each indicating if the sum of the values at those indices are within the limit
        // every array within queries[i] contains 2 elements, start and end index
        bool[] answers = new bool[queries.Length];

        int[] prefix = GetPrefixSum(nums);

        for (int i = 0; i < queries.Length; i++)
        {
            int firstIndex = queries[i][0];
            int secondIndex = queries[i][1];

            // second index - first index should give us the value we need?
            int sumOfPrefixBetweenIndices = (prefix[secondIndex] - prefix[firstIndex]) + nums[firstIndex];
            answers[i] = (sumOfPrefixBetweenIndices <= limit);
        }

        return answers;
    }

    public int GetNumOfSplitArrayWithBiggerLeft(int[] nums)
    {
        int[] prefix = GetPrefixSum(nums);
        int countOfBiggerLeftSpit = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            // find left sum prefix
            int left = prefix[i];
            int right = prefix[nums.Length - 1] - left;

            if (left > right)
            {
                countOfBiggerLeftSpit++;
            }
        }

        return countOfBiggerLeftSpit;
    }

    public int GetMinimumAverageDifference(int[] nums)
    {
        // find the "average difference" between indexes as we traverse the array
        // need to have the total for each index to divide by the index to find the average
        int minimumAverageIndex = 0;
        long minimumAverage = 0;
        long[] prefix = new long[nums.Length];
        prefix[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            prefix[i] += prefix[i - 1] + nums[i];
        }

        long averageOfLeft = 0,
            averageOfRight = 0;
        int numOfLeftIndexes = 1,
            numOfRightIndexes = nums.Length - numOfLeftIndexes;

        averageOfLeft = prefix[0] / numOfLeftIndexes;

        if (numOfRightIndexes > 0)
        {
            averageOfRight = (prefix[nums.Length - 1] - prefix[0]) / numOfRightIndexes;
        }

        minimumAverage = Math.Abs(averageOfLeft - averageOfRight);
        minimumAverageIndex = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            long tempMinimumAverage = 0;

            numOfLeftIndexes = i + 1;
            numOfRightIndexes = nums.Length - numOfLeftIndexes;

            averageOfRight = 0;
            averageOfLeft = prefix[i] / numOfLeftIndexes;

            if (numOfRightIndexes > 0)
            {
                averageOfRight = (prefix[nums.Length - 1] - prefix[i]) / numOfRightIndexes;
            }

            tempMinimumAverage = Math.Abs(averageOfLeft - averageOfRight);
            if (tempMinimumAverage < minimumAverage)
            {
                minimumAverage = tempMinimumAverage;
                minimumAverageIndex = i;
            }
        }

        return minimumAverageIndex;
    }
}