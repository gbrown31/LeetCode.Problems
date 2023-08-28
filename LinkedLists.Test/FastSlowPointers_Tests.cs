namespace LinkedLists.Test;

public class FastSlowPointers_Tests
{
    private readonly FastSlowPointers fastSlowPointers;

    public FastSlowPointers_Tests()
    {
        this.fastSlowPointers = new FastSlowPointers();
    }
    [Fact]
    public void DeleteMiddleNode()
    {
        ListNode node = new ListNode();
        node.val = 1;

        ListNode newNode = fastSlowPointers.DeleteMiddle(node);
        Assert.Null(newNode);
    }
}