using System.Runtime.Versioning;

namespace LinkedLists;

public class UsingPointers
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        ListNode slow = head;
        ListNode previousNode = null;
        while (slow != null)
        {
            if (previousNode != null)
            {
                int previousValue = 0,
                    nodeValue = 0;

                previousValue = previousNode.val;
                nodeValue = slow.val;

                if (previousValue == nodeValue)
                {
                    previousNode.next = slow.next;
                    slow = previousNode;
                }
            }

            previousNode = slow;
            slow = slow.next;
        }

        // initialise previous node to head
        // loop nodes
        // each node has next
        // if node.value == node.next.value
        // take previous node.next and point to node.next.next;
        return head;
    }

    public ListNode ReverseLinkedList(ListNode head)
    {
        ListNode prev = null;
        ListNode current = head;
        while (current != null)
        {
            // get reference to the next node
            ListNode nextNode = current.next;

            // reverse the direction of current and previous
            current.next = prev;
            // setup previous to be current
            prev = current;
            // set current to be next node
            current = nextNode;
        }

        return prev;
    }

    public ListNode ReverseNodesBetween(ListNode head, int left, int right)
    {
        // find starting position to reverse the nodes
        // we will changing the direction of the nodes starting from left through to right

        ListNode prev = null;
        ListNode current = head;
        while (left > 1)
        {
            prev = current;
            current = current.next;
            left--;
            right--;
        }
        // The two pointers that will fix the final connections.
        ListNode con = prev, 
            tail = current;

        // Iteratively reverse the nodes until n becomes 0.
        ListNode third = null;
        while (right > 0)
        {
            // get reference to the next node
            third = current.next;

            // reverse the direction of current and previous
            current.next = prev;
            // setup previous to be current
            prev = current;
            // set current to be next node
            current = third;
            right--;
        }

        // Adjust the final connections as explained in the algorithm
        if (con != null) {
            con.next = prev;
        } else {
            head = prev;
        }

        tail.next = current;
        return head;
    }

    public bool IsPalindrome(ListNode head)
    {
        List<int> values = new List<int>();
        List<int> reversedValues = new List<int>();
        ListNode current = head;
        while (current != null)
        {
            values.Add(current.val);
            current = current.next;
        }

        int i = 0,
            l = values.Count - 1;
        while (i < l)
        {
            if (values[i] != values[l])
            {
                return false;
            }
            i++;
            l--;
        }
        return true;
    }
}