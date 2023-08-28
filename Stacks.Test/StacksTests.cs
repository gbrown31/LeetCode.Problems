namespace Stacks.Test;

public class StacksTests
{
    [Theory]
    [InlineData(new object[] { "/home/", "/home"})]
    [InlineData(new object[] { "/../", "/"})]
    [InlineData(new object[] { "//home//foo", "/home/foo"})]
    public void SimplifyPath(string path, string expectedPath)
    {
        Stacks stacksStuff = new Stacks();

        string returnPath = stacksStuff.SimplifyPath(path);
        

        Assert.Equal(expectedPath, returnPath);
    }
}