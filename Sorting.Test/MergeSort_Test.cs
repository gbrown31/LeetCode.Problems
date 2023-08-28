namespace Sorting.Test;

public class MergeSort_Test
{
    [Fact]
    public void TestMergeSort()
    {
        MergeSort sort = new MergeSort();
        int[] result = sort.Sort(new int[] {6, 7, 2, 1, 3, 10});

        int[] expectedresult = new int[] {1, 2, 3, 6, 7, 10};
        for (int i = 0; i < result.Length; i++)
        {
            Assert.Equal(expectedresult[i], result[i]);
        }
    }
}