namespace Arrays;

public class LongestSubstring
{
    public int LengthOfLongestSubstringTwoDistinct(string s)
    {
        
        // find the longest substring within the array of characters
        // substring can only contain 2 characters
        // could make use of sliding windows
        // iterate over right, shifting the left pointer when we encounter a valid character    
        char[] characters = s.ToCharArray();

        Dictionary<char, int> charactersFound = new Dictionary<char, int>();
        int left = 0,
            maxSubstringLength = 0;
        for (int right = 0; right < characters.Length; right++)
        {
            if (!charactersFound.ContainsKey(characters[right]))
            {
                charactersFound.Add(characters[right], right);
            }
            else charactersFound[characters[right]] = right;
            

            while (charactersFound.Count > 2)
            {
                // find the left most character
                var key = charactersFound.OrderBy(a => a.Value).First();

                left = key.Value + 1;
                // remove character at left pointer
                charactersFound.Remove(key.Key);
            }

            int subStringLength = (right - left) + 1;
            maxSubstringLength = Math.Max(subStringLength, maxSubstringLength);
        }

        return maxSubstringLength;
    }
}