using System.Data;

namespace Trees;

public class BinaryTree
{
    public TreeNode InvertTree(TreeNode root)
    {
        // base case
        if (root == null)
        {
            return root; //?
        }

        TreeNode invertedRight = null,
            invertedLeft = null;
        //recursive call left
        if (root.left != null)
        {
            invertedLeft = InvertTree(root.left);
        }

        //recursive call right;
        if (root.right != null)
        {
            invertedRight = InvertTree(root.right);
        }

        root.left = invertedRight;
        root.right = invertedLeft;

        return root;
    }
    public int MaxAncestorDiff(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        int biggestLeftDifference = getBiggestAncestorDifference(root.left, root.val, root.val),
            biggestRightDifference = getBiggestAncestorDifference(root.right, root.val, root.val);

        return Math.Max(biggestLeftDifference, biggestRightDifference);
    }
    public int GetMaximumDepthOfTree(TreeNode root)
    {
        int currentMaximumDepth = 1;

        if (root == null)
        {
            return 0;
        }
        else
        {
            return findMaximumDepth(root, currentMaximumDepth);
        }
    }
    public int[] FindFrequentTreeSum(TreeNode root)
    {
        Dictionary<int, int> frequentTreeSum = new Dictionary<int, int>();
        if (root == null)
        {
            return frequentTreeSum.Values.ToArray();
        }

        GetFrequencyOfSubTreeSum(root, frequentTreeSum);

        List<int> maxValues = new List<int>();
        int maxValue = frequentTreeSum.Max(a => a.Value);
        foreach (var keyValue in frequentTreeSum)
        {
            if (keyValue.Value == maxValue)
            {
                maxValues.Add(keyValue.Key);
            }
        }

        return maxValues.ToArray();
    }

    private int GetFrequencyOfSubTreeSum(TreeNode node, Dictionary<int, int> valueCount)
    {
        // base case
        if (node == null)
        {
            return 0;
        }

        // work at this node and recursive down
        int left = GetFrequencyOfSubTreeSum(node.left, valueCount);
        int right = GetFrequencyOfSubTreeSum(node.right, valueCount);
        int subTreeSum = node.val + left + right;
        
        // finish work at this node and return
        if (valueCount.ContainsKey(subTreeSum))
        {
            valueCount[subTreeSum] += 1;
        }
        else valueCount.Add(subTreeSum, 1);

        return subTreeSum;
    }

    private int getBiggestAncestorDifference(TreeNode node, int smallest, int largest)
    {
        // base case
        if (node == null)
        {
            return largest - smallest;
        }

        // work at this node
        smallest = Math.Min(node.val, smallest);
        largest = Math.Max(node.val, largest);

        // recurse down
        int leftBiggestDifference = 0,
            rightBiggestDifference = 0;
        leftBiggestDifference = getBiggestAncestorDifference(node.left, smallest, largest);
        rightBiggestDifference = getBiggestAncestorDifference(node.right, smallest, largest);

        // finish work at this node
        return Math.Max(leftBiggestDifference, rightBiggestDifference);
    }
    private int findMaximumDepth(TreeNode root, int currentMaximumDepth)
    {
        if (root.left == null && root.right == null)
        {
            // we're a leaf, return currentMaximumDepth
            return currentMaximumDepth;
        }

        int maxLeftDepth = 0,
            maxRightDepth = 0;

        if (root.left != null)
        {
            // if there is a left child the depth must be currentDepth+1
            maxLeftDepth = findMaximumDepth(root.left, currentMaximumDepth + 1);
        }

        if (root.right != null)
        {
            // if there is a right child the depth must be currentDepth+1
            maxRightDepth = findMaximumDepth(root.right, currentMaximumDepth + 1);
        }

        // find biggest
        return Math.Max(maxLeftDepth, maxRightDepth);
    }
}