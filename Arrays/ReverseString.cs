public class ReverseString
{
    
    /// <summary>
    /// Reverse the passed in char array
    /// </summary>
    /// <tag>while loop, two pointers, array</tag>
    /// <bigO name="space">O(1)</bigO>
    /// <bigO name="time">O(n)</bigO>
    public char[] GetReverse(char[] s)
    {
        int i = 0,
            l = s.Length - 1;

        while (i < l)
        {
            char iChar = s[i],
                lChar = s[l];

            s[i] = lChar;
            s[l] = iChar;

            i++;
            l--;
        }

        return s;
    }
}