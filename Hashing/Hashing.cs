namespace Hashing;

public class Hashing
{
    public bool IsPangram(string sentence)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        HashSet<char> allLeters = new HashSet<char>(alphabet.ToCharArray());

        foreach (char s in sentence)
        {
            if (allLeters.Contains(s))
            {
                allLeters.Remove(s);
            }

            if (allLeters.Count == 0)
            {
                return true;
            }
        }

        return false;
    }

    public int MissingNumber(int[] nums)
    {
        int missingNumber = 0;
        HashSet<int> numbers = new HashSet<int>(nums);
        for (int i = 0; i <= numbers.Count; i++)
        {
            if (!numbers.Contains(i))
            {
                missingNumber = i;
            }
        }

        return missingNumber;
    }

    public int[] GetIntersection(int[] nums1, int[] nums2)
    {
        HashSet<int> result = new HashSet<int>();
        HashSet<int> firstSet = new HashSet<int>(nums1);
        for (int i = 0; i < nums2.Length; i++)
        {
            if (firstSet.Contains(nums2[i]))
            {
                result.Add(nums2[i]);
            }
        }

        return result.ToArray();
    }

    public int FindMaxLength(int[] nums)
    {
        // loop through the array to find the longest contiguous subarray
        // with equal number of 0 and 1
        int longestSubArray = 0;
        Dictionary<int, int> counter = new Dictionary<int, int>();
        counter.Add(0, 0);
        counter.Add(1, 0);
        // use left and right pointer to navigate the array
        int left = 0;
        for (int right = 0; right < nums.Length; right++)
        {
            int currentValue = counter.GetValueOrDefault(nums[right]);
            currentValue += 1;
            counter.Remove(nums[right]);
            counter.Add(nums[right], currentValue);

            int difference = Math.Abs(counter.GetValueOrDefault(0) - counter.GetValueOrDefault(1));
            while (right > 0 && difference > 1)
            {
                int leftValue = counter.GetValueOrDefault(nums[left]);
                leftValue -= 1;
                counter.Remove(nums[left]);
                counter.Add(nums[left], leftValue);

                difference = Math.Abs(counter.GetValueOrDefault(0) - counter.GetValueOrDefault(1));
                left++;
            }

            if (difference == 0)
            {
                longestSubArray = Math.Max(longestSubArray, (right - left) + 1);
            }
        }


        return longestSubArray;
    }

    public int FindMaxSubArray(int[] nums)
    {
        // looking for the largest sub array with an equal number of 0 and 1s
        // left and right pointers useless here as we're not interested
        return 0;
    }

    public bool DoesArrayHaveUniqueOccurrences(int[] arr)
    {
        bool isUnique = true;
        Dictionary<int, int> countOfInstances = new Dictionary<int, int>();
        countOfInstances.EnsureCapacity(1000);

        // loop array and populate dictionary with counts
        foreach (int i in arr)
        {
            int countOfInstance = 1;
            if (countOfInstances.ContainsKey(i))
            {
                countOfInstance = countOfInstances.GetValueOrDefault(i) + 1;
                countOfInstances[i] = countOfInstance;
            }
            else
            {
                countOfInstances.Add(i, countOfInstance);
            }
        }

        foreach (int i in arr)
        {
            if (countOfInstances.ContainsKey(i))
            {
                int count = countOfInstances[i];
                countOfInstances.Remove(i);

                if (countOfInstances.ContainsValue(count))
                {
                    isUnique = false;
                }
            }
        }

        return isUnique;
    }

    public bool IsUniqueOccurence(int[] arr)
    {
        Dictionary<int, int> occur = new Dictionary<int, int>();
        HashSet<int> res = new HashSet<int>();
        for (int i = 0; i < arr.Length; i++)
        {
            if (!occur.ContainsKey(arr[i]))
            {
                occur.Add(arr[i], 1);
            }
            else
            {
                occur[arr[i]]++;
            }
        }

        foreach (var item in occur)
        {
            if (!res.Contains(item.Value))
            {
                res.Add(item.Value);
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    public IList<IList<int>> FindWinners(int[][] matches)
    {
        SortedSet<int> playersWhoNeverLostSet = new SortedSet<int>();
        SortedSet<int> playersWhoLost1MatchSet = new SortedSet<int>();

        HashSet<int> players = new HashSet<int>();
        Dictionary<int, int> playersWhoLostCount = new Dictionary<int, int>();

        foreach (int[] match in matches)
        {
            int playerWhoWon = match[0],
                playerWhoLost = match[1];

            players.Add(playerWhoWon);
            players.Add(playerWhoLost);

            if (playersWhoLostCount.ContainsKey(playerWhoLost))
            {
                int countOfLostMatches = playersWhoLostCount[playerWhoLost];
                playersWhoLostCount[playerWhoLost] = countOfLostMatches + 1;
            }
            else
            {
                playersWhoLostCount.Add(playerWhoLost, 1);
            }
        }

        foreach (int player in players)
        {
            if (playersWhoLostCount.ContainsKey(player))
            {
                if (playersWhoLostCount[player] == 1)
                {
                    playersWhoLost1MatchSet.Add(player);
                }
            }
            else
            {
                playersWhoNeverLostSet.Add(player);
            }
        }

        return new List<IList<int>>()
        {
            playersWhoNeverLostSet.ToArray(), playersWhoLost1MatchSet.ToArray()
        };
    }

    public bool CanCreateRansomNotes(string ransomNote, string magazine)
    {
        Dictionary<char, int> ransomCharacterCount = new Dictionary<char, int>();

        // get a count of all the letter in the ransom note
        foreach (char letter in ransomNote)
        {
            if (ransomCharacterCount.ContainsKey(letter))
            {
                ransomCharacterCount[letter] += 1;
            }
            else
            {
                ransomCharacterCount.Add(letter, 1);
            }
        }

        foreach (char letter in magazine)
        {
            if (ransomCharacterCount.ContainsKey(letter))
            {
                int ransomeLetterInstances = ransomCharacterCount[letter] - 1;
                if (ransomeLetterInstances == 0)
                {
                    ransomCharacterCount.Remove(letter);
                }
                else
                {
                    ransomCharacterCount[letter] -= 1;
                }
            }
        }

        return ransomCharacterCount.Count == 0;
    }

    public int NumSubarraysWithSum(int[] nums, int goal)
    {
        // option 1
        // prefix sum of arrays
        // loop prefix?

        // option 2
        // sliding windows

        // 
        return 0;
    }

    public IList<string> WordSubsets(string[] words1, string[] words2)
    {
        List<string> result = new List<string>();
        // if words2 items always have a length of 1 then we could create a 
        // Dictionary of string, string[]
        Dictionary<char, List<string>> letterToWordsMap = new Dictionary<char, List<string>>();
        foreach (string word in words1)
        {
            foreach (char letter in word.ToCharArray())
            {
                if (letterToWordsMap.ContainsKey(letter))
                {
                    List<string> existingWords = letterToWordsMap[letter];
                    if (!existingWords.Contains(word))
                    {
                        existingWords.Add(word);
                        letterToWordsMap[letter] = existingWords;
                    }
                }
                else
                {
                    letterToWordsMap.Add(letter, new List<string>() {word});
                }
            }
        }

        List<string> wordsContainingLetters = new List<string>();
        foreach (string word in words2)
        {
            bool matchAllLetters = true;
            foreach (char letter in word.ToCharArray())
            {
                if (letterToWordsMap.ContainsKey(letter))
                {
                    wordsContainingLetters.AddRange(letterToWordsMap[letter]);
                }
            }
        }

        result.AddRange(wordsContainingLetters.GroupBy(s => s)
            .Select(s => new {Word = s.Key, Count = s.Count()})
            .Where(s => s.Count > 1).Select(s => s.Word).ToList());

        return result;
    }

    public IList<string> WordSubsets2(string[] words1, string[] words2)
    {
        Dictionary<string, int> wordsFound = new Dictionary<string, int>();
        foreach (string wordSubSetToMatch in words2)
        {
            foreach (string word in words1)
            {
                if (word.IndexOf(wordSubSetToMatch) >= 0)
                {
                    if (wordsFound.ContainsKey(word))
                    {
                        wordsFound[word] += 1;
                    }
                    else wordsFound.Add(word, 1);
                }
            }
        }

        return wordsFound.Where(w => w.Value == words2.Length).Select(w => w.Key).ToList();
    }
    
    public IList<string> WordSubsets3(string[] words1, string[] words2)
    {
        // foreach string in word2
        // get a hashset of char, int to count the characters in words2
        Dictionary<char, int> countOfChars = new Dictionary<char, int>();
        Dictionary<string, Dictionary<char, int>> wordsAndCharacterCount =
            new Dictionary<string, Dictionary<char, int>>();
        
        foreach (string subset in words2)
        {
            Dictionary<char, int> characterCount = new Dictionary<char, int>(); 
            foreach (char character in subset)
            {
                if (characterCount.ContainsKey(character))
                {
                    characterCount[character] += 1;
                }
                else characterCount.Add(character, 1);
            }

            foreach (string superSet in words1)
            {
                foreach (char superSetCharacter in superSet)
                {
                    if (characterCount.ContainsKey(superSetCharacter))
                    {
                        characterCount[superSetCharacter] -= 1;
                    }
                }
            }
        }
        
        
        Dictionary<string, int> wordsToCountOfWords2 = new Dictionary<string, int>();

        foreach (string subset in words2)
        {
            foreach (char charSubSet in subset)
            {
             
                
                
            }
        }
            
            


        List<string> result = new List<string>();
        foreach (string key in wordsToCountOfWords2.Keys)
        {
            if (wordsToCountOfWords2[key] == words2.Length)
            {
                result.Add(key);
            }
        }

        return result;
    }

    public IList<string> WordSubsets4(string[] words1, string[] words2)
    {
        
        // how to find if a string is a subset of another string
        return new List<string>();

    }

}