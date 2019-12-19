// Implement linked list

using System;
using System.Collections;
using System.Collections.Generic;

namespace Kcah
{
    public class LinkedListNode<T>
    {
        public T Data {get; set;}
        public LinkedListNode<T> Next {get; set;}

        public LinkedListNode(T data)
        {
            this.Data = data;
        }
    }
    public class LinkedList<T> 
    {
        public LinkedListNode<T> Head {get; set;}
        public LinkedListNode<T> Last {get; set;}

        public int Count {get; set;}

        public void Add(LinkedListNode<T> node)
        {
            if (node is null)
            { return; }

            if (this.Head is null)
            {
                this.Head = node;
                this.Last = node;
            }
            else
            {
                this.Last.Next = node;
                this.Last = node;
            }
        }

        public void Print()
        {
            LinkedListNode<T> t = this.Head;
            while (t != null)
            {
                Console.Write(Convert.ToString(t.Data) + "-->");
                t = t.Next;
            };
        }

    }

    public static class TestLinkedList
    {
        public static void TestLinkedList_AddNodes()
        {
            Kcah.LinkedList<int> l = new Kcah.LinkedList<int>();

            Kcah.LinkedListNode<int> n1 = new Kcah.LinkedListNode<int>(3);
            l.Add(n1);
            Kcah.LinkedListNode<int> n2 = new Kcah.LinkedListNode<int>(5);
            l.Add(n2);
            Kcah.LinkedListNode<int> n3 = new Kcah.LinkedListNode<int>(1);
            l.Add(n3);
            Kcah.LinkedListNode<int> n4 = new Kcah.LinkedListNode<int>(9);
            l.Add(n4);
            Kcah.LinkedListNode<int> n5 = new Kcah.LinkedListNode<int>(7);
            l.Add(n5);
            
            l.Print();            
        }
    }
}

