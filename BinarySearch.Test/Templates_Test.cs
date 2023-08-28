namespace BinarySearch.Test;

public class Templates_Test
{
    private readonly Templates templates;

    public Templates_Test()
    {
        this.templates = new Templates();
    }

    [Theory]
    [InlineData(new object[] {new int[] {1, 4, 6, 8, 10}, 7, -1})]
    [InlineData(new object[] {new int[] {1, 4, 6, 8, 10}, 6, 2})]
    public void FindTargetTest(int[] nums, int target, int expectedResult)
    {
        int result = templates.FindTarget(nums, target);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(new object[] {new int[] {1, 4, 6, 8, 10}, 7, 3})]
    [InlineData(new object[] {new int[] {1, 4, 6, 6, 8, 10}, 7, 4})]
    [InlineData(new object[] {new int[] {1, 4, 6, 8, 10}, 6, 2})]
    [InlineData(new object[] {new int[] {3, 4, 6, 8, 10}, 1, 0})]
    [InlineData(new object[] {new int[] {3, 4, 6, 8, 10}, 11, 5})]
    public void FindTargetOrLeftInsertionTest(int[] nums, int target, int expectedResult)
    {
        int result = templates.FindTargetOrLeftInsertion(nums, target);

        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData(new object[] {new int[] {1, 4, 6, 8, 10}, 7, 3})]
    [InlineData(new object[] {new int[] {1, 4, 6, 8, 10}, 6, 2})]
    [InlineData(new object[] {new int[] {1, 4, 6, 6, 8, 10}, 6, 2})]
    public void DuplicateTargetsLeftInsertionTest(int[] nums, int target, int expectedResult)
    {
        int result = templates.DuplicateTargetsLeftInsertion(nums, target);

        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData(new object[] {new int[] {1, 4, 6, 8, 10}, 7, 3})]
    [InlineData(new object[] {new int[] {1, 4, 6, 8, 10}, 6, 3})]
    [InlineData(new object[] {new int[] {1, 4, 6, 6, 8, 10}, 6, 4})]
    [InlineData(new object[] {new int[] {1, 4, 6, 6, 6, 8, 10}, 6, 5})]
    [InlineData(new object[] {new int[] {1, 4, 6, 6, 6, 6, 8, 10}, 6, 6})]
    public void DuplicateTargetsRightInsertionTest(int[] nums, int target, int expectedResult)
    {
        int result = templates.DuplicateTargetsRightInsertion(nums, target);

        Assert.Equal(expectedResult, result);
    }
}