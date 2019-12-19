
using System;

namespace Challenge
{
    public class LinkedList
    {
        private LinkedListNode head;
        public class LinkedListNode
        {
            public int Value {get; set;}
            public LinkedListNode Next {get; set;}

            public LinkedListNode(int val)
            {
                this.Value = val;
            }
        }

        public LinkedList()
        { }

        public LinkedListNode Head {get {return head;}}

        public void AddNode(int val)
        {
            LinkedListNode node = new LinkedListNode(val);

            if (this.Head == null)
            {
                head = node;
            }
            else
            {
                LinkedListNode t = head;
                while(t.Next != null)
                {
                    t = t.Next;
                }
                t.Next = node;
            }
        }

        // Select a Random Node from a Singly Linked List
        // Given a singly linked list, select a random node from linked list 
        // (the probability of picking a node should be 1/N if there are N nodes in list). 
        // You are given a random number generator.
        public LinkedListNode GetRandomNodeFromList()
        {
            int count = 0;

            LinkedListNode t = head;
            while(t.Next != null)
            {
                count++;
                t = t.Next;
            }

            Random rand = new Random();
            int index = rand.Next(count);

            t = head;
            count = 0;
            while(t.Next != null)
            {
                if (count == index)
                {
                    break;
                }
                count++;
                t = t.Next;
            }

            return t;
        }

        public static void Test_GetRandomNodeFromList()
        {
            LinkedList list = new LinkedList();
            list.AddNode(6);                                             
            list.AddNode(1);  
            list.AddNode(4);              
            list.AddNode(2);  
            list.AddNode(8);

            for(int i=1;i<=5;i++)
            { 
                Console.Write("Printing " + i.ToString() + " random node value from the list: ");
                Console.WriteLine(list.GetRandomNodeFromList().Value);
            }  
        }
    }
}