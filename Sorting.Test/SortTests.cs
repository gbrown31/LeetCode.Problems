namespace Sorting.Test;

public class SortTests
{
    [Fact]
    public void TestMergeSort()
    {
        Sort sort = new Sort();
        int[] result = sort.MergeSort(new int[] {6, 7, 2, 1, 3, 10});

        int[] expectedresult = new int[] {1, 2, 3, 6, 7, 10};
        for (int i = 0; i < result.Length; i++)
        {
            Assert.Equal(expectedresult[i], result[i]);
        }
    }
    [Theory]
    [InlineData(new object[]{ new int[] {6, 7, 2, 1, 3, 10}, new int[] {1, 2, 3, 6, 7, 10}})]
    //[InlineData(new object[]{ new int[] {13, 5, 15}, new int[] {5, 13, 15}})]
    public void TestQuickSort(int[] nums, int[] expectedResult)
    {
        Sort sort = new Sort();
        int[] result = sort.QuickSort(nums);

        for (int i = 0; i < result.Length; i++)
        {
            Assert.Equal(expectedResult[i], result[i]);
        }
    }
    [Fact]
    public void TestInsertionSort()
    {
        Sort sort = new Sort();
        int[] result = sort.InsertionSort(new int[] {6, 7, 2, 1, 3, 10});

        int[] expectedresult = new int[] {1, 2, 3, 6, 7, 10};
        for (int i = 0; i < result.Length; i++)
        {
            Assert.Equal(expectedresult[i], result[i]);
        }
    }

    [Fact]
    public void TestSelectionSort()
    {
        Sort sort = new Sort();
        int[] result = sort.SelectionSort(new int[] {6, 7, 2, 1, 3, 10});

        int[] expectedresult = new int[] {1, 2, 3, 6, 7, 10};
        for (int i = 0; i < result.Length; i++)
        {
            Assert.Equal(expectedresult[i], result[i]);
        }
    }
    [Fact]
    public void TestBubbleSort()
    {
        Sort sort = new Sort();
        int[] result = sort.BubbleSort(new int[] {6, 7, 2, 1, 3, 10});

        int[] expectedresult = new int[] {1, 2, 3, 6, 7, 10};
        for (int i = 0; i < result.Length; i++)
        {
            Assert.Equal(expectedresult[i], result[i]);
        }
    }
}