using LinkedLists;
using Queues;
using Xunit;

namespace QueuesTest;

public class Monotonic_Tests
{
    private readonly Monotonic queues;

    public Monotonic_Tests()
    {
        this.queues = new Monotonic();
    }

    [Theory]
    [InlineData(new object[] {new int[] {73, 74, 75, 71, 69, 72, 76, 73}, new int[] {1, 1, 4, 2, 1, 1, 0, 0}})]
    public void GetNextHotterDay(int[] temperatures, int[] daysUntilHotter)
    {
        int[] result = queues.DailyTemperatures(temperatures);

        Assert.Equal(daysUntilHotter.Length, result.Length);
        for (int i = 0; i < daysUntilHotter.Length; i++)
        {
            Assert.Equal(daysUntilHotter[i], result[i]);
            ;
        }
    }

    [Theory]
    [InlineData(new object[] {new int[] { 4,1,2}, new int[] {1,3,4,2 }, new int[] { -1,3,-1}})]
    public void GetNextGreaterElement(int[] nums1, int[] nums2, int[] expectedOutput)
    {
        int[] result = queues.NextGreaterElement(nums1, nums2);

        Assert.Equal(expectedOutput.Length, result.Length);
    }
    
    [Theory]
    [InlineData(new object[] {new int[] { 2,7,4,3,5}, new int[] {7,0,5,5,0}})]
    public void GetNextLargerNode(int[] nums1, int[] expectedOutput)
    {
        int[] result = queues.NextLargerNodes(nums1.ToListNode());

        Assert.Equal(expectedOutput.Length, result.Length);
    }
    
}