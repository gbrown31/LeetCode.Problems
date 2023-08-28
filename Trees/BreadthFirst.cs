namespace Trees;

public class BreadthFirst
{
    public void PrintAllNodesInLevel(TreeNode node)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(node);
        int depth = 1;
        Dictionary<int, int> sumAtDepth = new Dictionary<int, int>();
        while (queue.Count > 0)
        {
            // find number of items in the queue
            int nodesInLevel = queue.Count;
            depth++;
            // logic for current level goes here
            // I don't have the nodes in level here
            // perhaps I setup variables to track

            int sumOfAllNodesOnLevel = 0;

            // loop over them
            for (int i = 0; i < nodesInLevel; i++)
            {
                TreeNode myNode = queue.Dequeue();
                sumOfAllNodesOnLevel += myNode.val;
                if (node.left != null)
                {
                    sumOfAllNodesOnLevel += node.left.val;
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    sumOfAllNodesOnLevel += node.right.val;
                    queue.Enqueue(node.right);
                }
            }

            sumAtDepth.Add(depth, sumOfAllNodesOnLevel);
            //sumOfAllNodesOnLevel should now include all nodes on this level
        }
    }

    public int DeepestLeavesSum(TreeNode root)
    {
        Dictionary<int, int> sumByDepth = new Dictionary<int, int>();
        // add node onto the queue
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int depth = 1;
        // loop while queue not empty
        while (queue.Count > 0)
        {
            // setup level variables
            int sizeOfQueue = queue.Count;
            int sumAtDepth = 0;
            // for loop queue size
            for (int i = 0; i < sizeOfQueue; i++)
            {
                // pop the first node off the queue
                TreeNode levelNode = queue.Dequeue();
                sumAtDepth += levelNode.val;

                // add left child
                if (levelNode.left != null)
                {
                    queue.Enqueue(levelNode.left);
                }

                // add right child
                if (levelNode.right != null)
                {
                    queue.Enqueue(levelNode.right);
                }
            }

            depth++;
            sumByDepth.Add(depth, sumAtDepth);
        }

        // not the biggest value but the deepest value
        int deepestLevel = sumByDepth.Max(a => a.Key);
        return sumByDepth[deepestLevel];
    }

    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        // zig zag is left then right?
        List<IList<int>> zigZagNodes = new List<IList<int>>();

        if (root == null)
        {
            return zigZagNodes;
        }
        
        // create a queue
        Queue<TreeNode> queue = new Queue<TreeNode>();
        // push root node onto queue
        queue.Enqueue(root);
        bool leftToRight = true;

        // while queue is not empty
        while (queue.Count > 0)
        {
            // find size of the queue
            // - this is the number of nodes on the level
            int noNodesOnLevel = queue.Count;
            LinkedList<int> nodesOnLevelList = new LinkedList<int>();
            // for loop these nodes
            for (int i = 0; i < noNodesOnLevel; i++)
            {
                // pop node
                TreeNode nodeOnLevel = queue.Dequeue();
                //  - do work
                if (leftToRight)
                {
                    nodesOnLevelList.AddLast(nodeOnLevel.val);
                }
                else
                {
                    nodesOnLevelList.AddFirst(nodeOnLevel.val);
                }
                // add left child
                if (nodeOnLevel.left != null)
                {
                    queue.Enqueue(nodeOnLevel.left);
                }
                // add right child
                if (nodeOnLevel.right != null)
                {
                    queue.Enqueue(nodeOnLevel.right);
                }
            }
            leftToRight = !leftToRight;
            zigZagNodes.Add(nodesOnLevelList.ToList());
        }

        return zigZagNodes;
    }
}