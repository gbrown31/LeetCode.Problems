namespace Trees.Test;

public class BinaryTree_Tests
{
    private readonly BinaryTree binaryTree;

    public BinaryTree_Tests()
    {
        this.binaryTree = new BinaryTree();
    }

    [Fact]
    public void GetMaximumDepthOfTree()
    {
        int?[] nodeArray = new int?[] {3, 9, 20, null, null, 15, 7};

        TreeNode root = nodeArray.ToTreeNode();

        int maxDepth = binaryTree.GetMaximumDepthOfTree(root);

        Assert.Equal(3, maxDepth);
    }

    [Theory]
    // [InlineData(new object[]{ new int[] {8, 3, 10, 1, 6, -111102, 14, -111102, -111102, 4, 7, 13}, 7 })]
    // [InlineData(new object[] {new int[] {0,-111102,1}, 1})]
    [InlineData(new object[] {new int[] {2,0,-111102, 1}, 2})]
    public void GetBiggestAncestorDifference(int[] nodeArray, int expectedResult)
    { 
        TreeNode root = nodeArray.ToTreeNode(-111102);

        int biggestDifference = binaryTree.MaxAncestorDiff(root);

        Assert.Equal(expectedResult, biggestDifference);
    }

    [Theory]
    [InlineData(new object[] {new int[] { 5,2,-3}, new int[] {2,-3,4 }})]
    [InlineData(new object[] {new int[] { 5,2,-5}, new int[] {2 }})]
    [InlineData(new object[] {new int[] { 5, 14,-0111102,1 }, new int[] {1,15,20 }})]
    public void GetFrequentTreeSum(int[] treeNodes, int[] expectedResult)
    {
        TreeNode root = treeNodes.ToTreeNode(-0111102);

        int[] result = binaryTree.FindFrequentTreeSum(root);

        Assert.Equal(expectedResult.Length, result.Length);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            Assert.Contains(expectedResult[i], result.ToList());
        }
    }

    [Fact]
    public void ConvertArrayToTreeNode()
    {
        var array = new int[] {5, 2, -3};
        TreeNode node = array.ConstructTree();
    }
}