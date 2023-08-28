namespace Backtracking;

public class IncreasingSubsequences
{
    public IList<IList<int>> FindSubsequences(int[] nums)
    {
        var answer = new List<IList<int>>();

        LinkedList<int> list = new LinkedList<int>();
        HashSet<string> visited = new HashSet<string>();

        //backtrack(list, answer, nums, 0);
        subsetsBacktrack(list, 0, answer, nums, visited);

        return answer;
    }

    private void subsetsBacktrack(LinkedList<int> curr, int i, List<IList<int>> ans, int[] nums, HashSet<string> visited)
    {
        if (curr.Count > 1)
        {
            string str = String.Join(",", curr.ToArray());
            if (!visited.Contains(str))
            {
                ans.Add(new List<int>(curr));
                visited.Add(str);
            }
        }

        for (int j = i; j < nums.Length; j++)
        {
            bool addToCurrent = (curr.Count == 0 || (curr.Count > 0 && nums[j] >= curr.Last.Value));
            if (addToCurrent)
            {
                curr.AddLast(nums[j]);
                subsetsBacktrack(curr, j + 1, ans, nums, visited);
                curr.RemoveLast();
            }
        }
    }
}