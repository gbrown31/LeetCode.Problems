namespace Arrays.Test;

public class LongestSubstring_Test
{
    [Fact]
    public void GetLonestSubstring()
    {
        LongestSubstring strings = new LongestSubstring();
        int length = strings.LengthOfLongestSubstringTwoDistinct("eceba");
        Assert.Equal(3, length);
    }
}