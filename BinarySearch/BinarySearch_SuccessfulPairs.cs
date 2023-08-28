using System.Collections.Immutable;

namespace BinarySearch;

public class BinarySearch_SuccessfulPairs
{
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        // spells and potions arrays contain the strength of each spell or potion
        // a spell and potion combination is considered successful if for i and j:
        // spell[i] * potion[j] >= success

        // looking to return a integer where answer[i] is the number of successful potion pairs
        // for that spell

        // create answer array of length spells
        int[] answer = new int[spells.Length];

        // sort the potions to make them searchable
        Array.Sort(potions);

        // foreach spell create a target by success / spells[i]
        for (int i = 0; i < spells.Length; i++)
        {
            decimal target = success / (decimal) spells[i];
            int j = binarySearch(potions, target);

            answer[i] = potions.Length - j;
        }

        return answer;
    }

    // FindTargetOrLeftInsertion
    // ignore target found as on last run left would be pointing at target
    // but why ignore the target? because the target is a
    // decimal number we're never going to find it
    public int binarySearch(int[] arr, decimal target)
    {
        int left = 0;
        int right = arr.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return left;
    }
}