namespace LinkedLists;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public static class ListNodeExtension
{
    public static int[] ToArray(this ListNode node)
    {
        List<int> valuesFromNodes = new List<int>();

        ListNode currentNode = node;
        while (currentNode != null)
        {
            valuesFromNodes.Add(currentNode.val);
            currentNode = currentNode.next;
        }

        return valuesFromNodes.ToArray();
    }

    public static ListNode ToListNode(this int[] array)
    {
        ListNode head = new ListNode();
        head.val = array[0];

        ListNode currentNode = head;
        for (int i = 1; i < array.Length; i++)
        {
            currentNode.next = new ListNode(array[i]);
            
            currentNode = currentNode.next;
        }

        return head;
    }
}