namespace Hashing.Test;

public class Hashing_Tests
{
    private readonly Hashing hashing;

    public Hashing_Tests()
    {
        this.hashing = new Hashing();
    }

    [Theory]
    [InlineData(new object[] {"thequickbrownfoxjumpsoverthelazydog", true})]
    [InlineData(new object[] {"thequickdog", false})]
    public void CheckIsPangram(string sentence, bool expectedPangram)
    {
        bool result = hashing.IsPangram(sentence);

        Assert.Equal(expectedPangram, result);
    }

    [Theory]
    [InlineData(new object[] {new int[] {3, 0, 1}, 2})]
    [InlineData(new object[] {new int[] {0, 1}, 2})]
    public void FindMissingNumbers(int[] nums, int expectedMissing)
    {
        int result = hashing.MissingNumber(nums);

        Assert.Equal(expectedMissing, result);
    }

    [Theory]
    [InlineData(new object[] {new int[] {1, 2, 2, 1}, new int[] {2, 2}, new int[] {2}})]
    public void GetIntersectionofArrays(int[] nums, int[] nums2, int[] expectedResult)
    {
        int[] result = hashing.GetIntersection(nums, nums2);

        HashSet<int> hResults = new HashSet<int>(result);
        HashSet<int> hExpectedResult = new HashSet<int>(expectedResult);

        for (int i = 0; i < result.Length; i++)
        {
            Assert.True(expectedResult.Contains(result[i]));
        }
    }


    [Theory]
    [InlineData(new object[] {new int[] {0, 1, 0}, 2})]
    public void FindMaxLengthBinarySubArray(int[] nums, int expectedLength)
    {
        int result = hashing.FindMaxLength(nums);

        Assert.Equal(expectedLength, result);
    }
    [Theory]
    [InlineData(new object[] {new int[] {0, 1, 0}, true})]
    [InlineData(new object[] {new int[] {0, 1, 1, 0}, false})]
    public void IsUniqueOccurrences(int[] nums, bool expectedResult)
    {
        bool result = hashing.DoesArrayHaveUniqueOccurrences(nums);

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GetWinnersAnd1MatchLosers()
    {
        int[][] expectedResult = new int[][] {new int[] {1, 2, 10}, new int[] {4, 5, 7, 8}};

        int[][] matches = new int[][]
        {
            new int[] {1, 3}, new int[] {2, 3}, new int[] {3, 6}, new int[] {5, 6},
            new int[] {5, 7}, new int[] {4, 5}, new int[] {4, 8}, new int[] {4, 9}, new int[] {10, 4}, new int[] {10, 9}
        };

        var winnersAnd1MatchLoser =  hashing.FindWinners(matches);


        int[] winners = expectedResult[0],
            lost1Match = expectedResult[1];

        var winnersResult = winnersAnd1MatchLoser.First();
        var lost1MatchResult = winnersAnd1MatchLoser.Last();

        for (int i = 0; i < winners.Length; i++)
        {
            Assert.Equal(winners[i], winnersResult[i]);
        }

        for (int i = 0; i < lost1Match.Length; i++)
        {
            Assert.Equal(lost1Match[i], lost1MatchResult[i]);
        }
    }

    [Fact]
    public void CanCreateRansomNote()
    {
        Assert.True(hashing.CanCreateRansomNotes("abc", "abbbbc"));
    }

    [Theory]
    [InlineData(new object[]{new[] {"amazon", "apple", "facebook", "google", "leetcode"}, new[] {"e", "o"}, new[] {"facebook","google", "leetcode"}})]
    [InlineData(new object[]{new[] {"amazon", "apple", "facebook", "google", "leetcode"}, new[] {"l", "e"}, new[] {"apple","google", "leetcode"}})]
    public void WordSubsets(string[] word1, string[] word2, string[] expectedWords)
    {
        var words = hashing.WordSubsets2(word1, word2);

        foreach (string expectedWord in expectedWords)
        {
            Assert.True(words.Contains(expectedWord));
        }
    }
}