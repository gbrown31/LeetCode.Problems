namespace Trees;


public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public static class TreeNodeExtensions
{
    public static TreeNode ToTreeNode(this int?[] array)
    {
        TreeNode root = new TreeNode();
        root = insertLevelOrder(array, 0);
        return root;
    }
    public static TreeNode ToTreeNode(this int[] array, int valueToTreatAsNull)
    {
        TreeNode root = new TreeNode();
        //root = DoTreeArray(array, 0);
        root = insertLevelOrder(array, 0, valueToTreatAsNull);
        return root;
    }
    
    public static TreeNode ConstructTree(this int[] array)
    {
        TreeNode root = BuildTree(array, 0);
        return root;
    }

    private static TreeNode BuildTree(int[] values, int index)
    {
        TreeNode node = new TreeNode(values[index]);
        
        if (index * 2 + 1 < values.Length)
        {
            node.left = BuildTree(values, index * 2 + 1);
        }
        if (index * 2 + 2 < values.Length)
        {
            node.right = BuildTree(values, index * 2 + 2);
        }

        return node;
    }

    private static TreeNode DoTreeArray(int[] arr, int position)
    {
        if (arr.Length == 0)
        {
            return null;
        }
        TreeNode node = new TreeNode(arr[position]);
        int leftChildPosition = position * 2,
            rightChildPosiiton = leftChildPosition + 1;

        // do left child build
        // do right child build
        if (arr.Length >= leftChildPosition)
        {
            node.left = DoTreeArray(arr, leftChildPosition);
        }
        if (arr.Length >= rightChildPosiiton)
        {
            node.right = DoTreeArray(arr, rightChildPosiiton);
        }

        return node;
    }
    private static TreeNode insertLevelOrder(int[] arr, int i, int valueToTreeAsNullIdentifier)
    {
        TreeNode root = null;
        // Base case for recursion
        if (i < arr.Length) 
        {
            root = new TreeNode();
            
            if (arr[i] != valueToTreeAsNullIdentifier)
            {
                root.val = arr[i];
            }
            else return null;
  
            // insert left child
            root.left = insertLevelOrder(arr, 2 * i + 1, valueToTreeAsNullIdentifier);
  
            // insert right child
            root.right = insertLevelOrder(arr, 2 * i + 2, valueToTreeAsNullIdentifier);
        }
        return root;
    }
    private static TreeNode insertLevelOrder(int?[] arr, int i)
    {
        TreeNode root = null;
        // Base case for recursion
        if (i < arr.Length) 
        {
            root = new TreeNode();
            if (arr[i].HasValue)
            {
                root.val = arr[i].Value;
            }
            else return null;
  
            // insert left child
            root.left = insertLevelOrder(arr, 2 * i + 1);
  
            // insert right child
            root.right = insertLevelOrder(arr, 2 * i + 2);
        }
        return root;
    }

    // private static TreeNode buildLevelFromArray(int[] array, int i, int depth, int previousLevelNodesCount)
    // {
    //     List<TreeNode> parentNodes = new List<TreeNode>();
    //     // need starting position to loop array
    //     int noNodesOnLevel = previousLevelNodesCount * 2;
    //
    //     Queue<TreeNode> queue = new Queue<TreeNode>();
    //     for (int startPosition = 0; startPosition < noNodesOnLevel; startPosition++)
    //     {
    //         // loop subarray startPosition to end
    //         queue.Enqueue(new TreeNode(array[startPosition]));
    //     }
    //
    //     while (queue.Count > 0)
    //     {
    //         int queueSize = queue.Count;
    //         for (int a = 0; a < queueSize; a++)
    //         {
    //             TreeNode left = queue.Dequeue(),
    //                 right = null;
    //             queue.TryDequeue(out right);
    //             a++;
    //             int parentPosition = a / 2;
    //             parentNodes[parentPosition].left = left;
    //             parentNodes[parentPosition].right = right;
    //         }
    //     }
    //     
    //     
    //     
    //     // build current level
    //     
    //     // depth = 2, 3
    //     // previousLevelNodesCount = 1, 2,
    //
    // }
}