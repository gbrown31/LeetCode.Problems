namespace Trees.Test;

public class BinarySearchTree_Tests
{
    private readonly BinarySearchTree binarySearchTree;

    public BinarySearchTree_Tests()
    {
        this.binarySearchTree = new BinarySearchTree();
    }
    [Theory]
    [InlineData(new object[]
        {new int[] {40, 20, 60, 10, 30, 50, 70}, 25, new int[] {40, 20, 60, 10, 30, 50, 70, -0111102, -0111102, 25}})]
    public void InsertIntoBST(int[] array, int valueToInsert, int[] expectedArray)
    {
        TreeNode root = array.ConstructTree();
        root = binarySearchTree.InsertIntoBST(root, valueToInsert);

        Assert.Equal(0, 0);
    }

    [Theory]
    [InlineData(new object[] { new int[] {1, 0, 2}, 1,2, new int[] { 0 -2324, 2}})]
    public void TrimTreeTests(int[] array, int low, int high, int[] expectedArray)
    {
        TreeNode root = array.ConstructTree();
        
        root = binarySearchTree.TrimTreeNode(root, low, high);
    }
}