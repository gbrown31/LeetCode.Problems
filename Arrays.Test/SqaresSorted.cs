namespace Arrays.Test
{
    public class SqaresSorted
    {

        [Theory]
        [InlineData(new int[] { -4, -1, 0, 3, 10 }, new int[] {0, 1, 9, 16, 100 })]
        public void Test(int[] input, int[] expectedResult)
        {
            int[] result = SortedSquares(input);

            Assert.Equal<int[]>(expectedResult, result);
        }

        public int[] SortedSquares(int[] nums)
        {
            int left = 0,
                right = nums.Length - 1;

            while (left < right)
            {
                int leftValue = Math.Abs(nums[left]),
                    rightValue = Math.Abs(nums[right]);

                Console.WriteLine($"{leftValue} is sqr {Math.Pow(leftValue, 2)}");
                Console.WriteLine($"{rightValue} is sqr {Math.Pow(rightValue, 2)}");        
                

                // do math sqrt call
                nums[left] = (int)Math.Pow(leftValue, 2);
                nums[right] = (int)Math.Pow(rightValue, 2);

                left++;
                right--;

                // reached the middle item
                if (left == right)
                {
                    nums[left] = (int)Math.Pow(Math.Abs(nums[left]), 2);
                }
            }
            Array.Sort(nums);
            return nums;
        }
    }
}
