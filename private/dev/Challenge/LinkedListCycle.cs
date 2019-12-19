using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge
{
    /**
     * Definition for singly-linked list.
     * class ListNode {
     *     public int val;
     *     public ListNode next;
     *     ListNode(int x) { val = x; next = null; }
     * }
     */
    public class Solution
    {
        public class ListNode
        {
            public int value;
            public ListNode next;
        }
        public ListNode detectCycle(ListNode node)
        {
            if (node == null || node.next == null)
            {
                return null;
            }

            ListNode slow = node;
            ListNode fast = node.next;

            while (slow.next != null && fast.next != null)
            {
                if (slow == fast)
                {
                    return fast;
                }
                slow = slow.next;
                fast = fast.next;
            }
            return null;
        }
    }
}
