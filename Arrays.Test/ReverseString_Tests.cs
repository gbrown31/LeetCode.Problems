namespace Arrays.Test;

public class ReverseString_Tests
{
    [Fact]
    public void GetReverseString()
    {
        char[] myString = new[] {'h', 'e', 'l', 'l', 'o'};

        ReverseString reverseString = new ReverseString();

        char[] result = reverseString.GetReverse(myString);

        Assert.Equal("olleh", string.Join("", result));
    }

    [Theory]
    [InlineData(new object[] {new[] {'h', 'e', 'l', 'l', 'o'}, "olleh"})]
    [InlineData(new object[] {new[] {'h', 'e', 'l', 'o'}, "oleh"})]
    [InlineData(new object[] {new[] {'h', 'e', 'l' }, "leh"})]
    public void GetReverseOfString(char[] s, string expected)
    {
        ReverseString reverseString = new ReverseString();

        char[] result = reverseString.GetReverse(s);

        Assert.Equal(expected, string.Join("", result));
    }
}