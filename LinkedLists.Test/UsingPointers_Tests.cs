namespace LinkedLists.Test;

public class UsingPointers_Tests
{
    private readonly UsingPointers pointers;

    public UsingPointers_Tests()
    {
        this.pointers = new UsingPointers();
    }

    [Theory]
    [InlineData(new object[] {new int[] {1, 1, 2}, new int[] {1, 2}})]
    [InlineData(new object[] {new int[] {1, 1, 1}, new int[] {1}})]
    public void DeleteDuplicateNodes(int[] input, int[] expectedOutput)
    {
        ListNode node = pointers.DeleteDuplicates(input.ToListNode());

        int[] result = node.ToArray();

        Assert.Equal(expectedOutput.Length, result.Length);
        for (int i = 0; i < expectedOutput.Length; i++)
        {
            Assert.Equal(expectedOutput[i], result[i]);
        }
    }

    [Theory]
    [InlineData(new object[] {new int[] {1, 1, 2}, new int[] {2, 1, 1}})]
    [InlineData(new object[] {new int[] {1, 1, 1}, new int[] {1, 1, 1}})]
    [InlineData(new object[] {new int[] {1, 1, 1, 3, 2, 1}, new int[] {1, 2, 3, 1, 1, 1}})]
    public void ReverseLinkedList(int[] input, int[] expectedOutput)
    {
        ListNode node = pointers.ReverseLinkedList(input.ToListNode());

        int[] result = node.ToArray();

        Assert.Equal(expectedOutput.Length, result.Length);
        for (int i = 0; i < expectedOutput.Length; i++)
        {
            Assert.Equal(expectedOutput[i], result[i]);
        }
    }

    [Theory]
    [InlineData(new object[] {new int[] {1, 2, 3, 4, 5}, 2, 4, new[] {1, 4, 3, 2, 5}})]
    [InlineData(new object[] {new[] {5}, 1, 1, new int[] {5}})]
    [InlineData(new object[] {new[] {3, 5}, 1, 2, new int[] {5, 3}})]
    [InlineData(new object[] {new[] {1, 2, 3}, 1, 2, new int[] {2, 1, 3}})]
    public void ReverseNodesAtPoisiton(int[] input, int left, int right, int[] expectedOutput)
    {
        ListNode node = pointers.ReverseNodesBetween(input.ToListNode(), left, right);

        int[] result = node.ToArray();
        Assert.Equal(expectedOutput.Length, result.Length);
        for (int i = 0; i < expectedOutput.Length; i++)
        {
            Assert.Equal(expectedOutput[i], result[i]);
        }
    }

    [Theory]
    [InlineData(new object[] {new int[] {1, 2, 3, 4, 5}, 2, 4, new[] {1, 4, 3, 2, 5}})]
    [InlineData(new object[] {new[] {5}, 1, 1, new int[] {5}})]
    [InlineData(new object[] {new[] {3, 5}, 1, 2, new int[] {5, 3}})]
    [InlineData(new object[] {new[] {1, 2, 3}, 1, 2, new int[] {2, 1, 3}})]
    public void ReverseNodesAtPoisiton2(int[] input, int left, int right, int[] expectedOutput)
    {
        ListNode node = pointers.ReverseNodesBetween(input.ToListNode(), left, right);

        int[] result = node.ToArray();
        Assert.Equal(expectedOutput.Length, result.Length);
        for (int i = 0; i < expectedOutput.Length; i++)
        {
            Assert.Equal(expectedOutput[i], result[i]);
        }
    }

    [Theory]
    [InlineData(new object[] {new int[] {1, 2, 2, 1}, true})]
    public void IsPalindrome(int[] input, bool expectedOutput)
    {
        bool isPalindrome = pointers.IsPalindrome(input.ToListNode());

        Assert.Equal(expectedOutput, isPalindrome);
    }
}