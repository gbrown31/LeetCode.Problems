using System.Collections.ObjectModel;

namespace Backtracking;

public class Generation
{
    public IList<IList<int>> Permute(int[] nums)
    {
        // return a list of all possible permutations of the integers in nums
        List<IList<int>> ans = new List<IList<int>>();
        permuteBacktrack(new List<int>(), ans, nums);
        return ans;
    }

    private void permuteBacktrack(List<int> curr, List<IList<int>> ans, int[] nums)
    {
        // base case
        // if curr has a list which matches the length of the original nums
        // then add it to the answer
        if (curr.Count == nums.Length)
        {
            ans.Add(new List<int>(curr));
            return;
        }

        // foreach of the original numbers
        foreach (int num in nums)
        {
            // if it doesn't exist in the list
            if (!curr.Contains(num))
            {
                // add to the list
                curr.Add(num);
                // call backtrack to add the next or return
                permuteBacktrack(curr, ans, nums);
                // why remove here?
                curr.RemoveAt(curr.Count - 1);
            }
        }
    }

    public IList<IList<int>> Subsets(int[] nums)
    {
        List<IList<int>> ans = new List<IList<int>>();
        subsetsBacktrack(new List<int>(), 0, ans, nums);
        return ans;
    }

    private void subsetsBacktrack(List<int> curr, int i, List<IList<int>> ans, int[] nums)
    {
        // if i exceeds nums indexes then return
        if (i > nums.Length)
        {
            return;
        }

        // add curr to ans as it represents a subset
        ans.Add(new List<int>(curr));
        for (int j = i; j < nums.Length; j++)
        {
            curr.Add(nums[j]);
            subsetsBacktrack(curr, j + 1, ans, nums);
            curr.RemoveAt(curr.Count - 1);
        }
    }

    public void fixedSizeBacktracking(List<int> curr, int j, List<List<int>> ans, int n, int k)
    {
        // once the count of numbers in the list has reached size of k
        // then return as answer
        if (curr.Count == k)
        {
            ans.Add(new List<int>(curr));
            return;
        }

        for (int num = j; num <= n; num++)
        {
            curr.Add(num);
            fixedSizeBacktracking(curr, num + 1, ans, n, k);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}