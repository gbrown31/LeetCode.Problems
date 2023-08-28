namespace Trees;

public class BinarySearchTree
{
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root == null)
        {
            return new TreeNode(val);
        }
        
        // if value > root.value go right
        // else if value < root.value go left
        addNodeToTree(root, val);

        return root;
    }

    private TreeNode addNodeToTree(TreeNode node, int val)
    {
        if (node == null)
        {
            // reach end of the line
            // create new node?
            node = new TreeNode(val);
        }
        
        if (val< node.val)
        {
            node.left = addNodeToTree(node.left, val);
        }
        else if (val > node.val)
        {
            node.right = addNodeToTree(node.right, val);
        }

        return node;
    }

    public TreeNode TrimTreeNode(TreeNode root, int low, int high)
    {
        // base case
        if (root == null)
        {
            return root;
        }
        
        // traverse nodes
        return removeNodesBetweenLimit(root, low, high);
    }

    private TreeNode removeNodesBetweenLimit(TreeNode node, int low, int high)
    {
        // base case
        TreeNode nodeToReturn = null;
        if (node == null)
        {
            return node;
        }

        // recursive call to children
        if (node.left != null)
        {
            node.left = removeNodesBetweenLimit(node.left, low, high);
        }

        if (node.right != null)
        {
            node.right = removeNodesBetweenLimit(node.right, low, high);
        }

        // result find which of the nodes to return
        if (node.val < low)
        {
            nodeToReturn = node.right;
        }
        else if (node.val > high)
        {
            nodeToReturn = node.left;
        }
        else if (node.val >= low && node.val <= high)
        {
            nodeToReturn = node;
        }

        return nodeToReturn;
    }
}