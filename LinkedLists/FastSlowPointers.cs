namespace LinkedLists;

public class FastSlowPointers
{
    public ListNode DeleteMiddle(ListNode head)
    {
        // for a given head find the middle node and delete it
        // use fast and slow pointers
        // when fast pointer reaches the end of the list the slow pointer should be in the middle
        
        // to delete the node from the list reassign the previous node next to be next nodes previous
        ListNode nodeBeforeSlow = null;
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            nodeBeforeSlow = slow;
            slow = slow.next;
            fast = fast.next.next;
        }
        
        // at the end of this loop slow should now be the middle node
        // how do I get a pointer to previous?
        // nothing to delete
        if (nodeBeforeSlow != null)
        {
            nodeBeforeSlow.next = slow.next;
        }
        else
        {
            // single node in linked list, set to null
            head = null;
        }

        return head;
    }

}