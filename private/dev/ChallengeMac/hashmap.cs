// Implement hashtable as an array of linked list

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Diagnostics;

namespace Kcah
{
    public class HashMap<T1, T2> : System.Collections.Generic.IEnumerable<T1> 
    {
        private LinkedList<T1, T2>[] map = null;

        private int GetHashCode(T1 key)
        {
            return Math.Abs(Convert.ToString(key).GetHashCode() % this.Capacity);
        }

        public int Capacity {get; set;}

        public HashMap()
        {
            if (this.Capacity == 0)
            { this.Capacity = 100; }

            map = new LinkedList<T1, T2>[this.Capacity];
        }

        public void Put(T1 key, T2 value)
        {
            int hash = this.GetHashCode(key);
            LinkedList<T1, T2> list = map[hash];
            LinkedListNode<T1, T2> node = new LinkedListNode<T1, T2>(key, value);

            if (list != null)
            {
                LinkedListNode<T1, T2> t = list.Head;
                do
                { 
                    if (t.Key.ToString() == Convert.ToString(key))
                    {
                        throw new Exception("Key already exists");
                    }
                    t = t.Next; 
                }
                while(t.Next != null);
            }

            list = new LinkedList<T1, T2>();
            list.Add(node);
            map[hash] = list;
        }

        public T2 Get(T1 key)
        {
            int hash = this.GetHashCode(key);
            LinkedList<T1, T2> list = map[hash];
            
            if (list is null)
            { throw new KeyNotFoundException(); }

            LinkedListNode<T1, T2> t = list.Head;
            do
            { 
                if (t.Key.ToString() == Convert.ToString(key))
                {
                    return t.Value;
                }
                list.Last = list.Last.Next; 
            }
            while(t.Next != null);

            throw new KeyNotFoundException();
        }

        public T2 this[T1 key]
        {
            get{ return Get(key);}
        }

        public IEnumerator<T1> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            // Lets call the generic version here
            return this.GetEnumerator();
        }

        public void Print()
        {
            foreach (LinkedList<T1,T2> l in map)
            {

            }
        }
    }

    internal class LinkedListNode<K, V>
    {
        public K Key {get; set;}
        public V Value {get; set;}
        public LinkedListNode<K, V> Next {get; set;}

        public LinkedListNode(K key, V value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
    internal class LinkedList<K, V> 
    {
        public LinkedListNode<K, V> Head {get; set;}
        public LinkedListNode<K, V> Last {get; set;}

        public int Count {get; set;}

        public void Add(LinkedListNode<K,V> node)
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
            LinkedListNode<K,V> t = this.Head;
            while (t != null)
            {
                Console.Write(Convert.ToString(t.Key) + "," + Convert.ToString(t.Value) + "-->");
                t = t.Next;
            };
        }

    }

    public static class TestHashmap
    {
        public static void TestHashMap_PutGetKeyValue()
        {
            HashMap<string, string> map = new HashMap<string, string>();
            map.Put("a", "1");
            map.Put("b", "2");
            map.Put("c", "3");
            map.Put("d", "4");

            Debug.Assert(Convert.ToString(map.Get("a")) == "2", "map.Get(a) != 2; so this assertion should fail.");
            Debug.Assert(Convert.ToString(map["a"]) == "1", "map[a] = 1; so this is great!");
        }
    }
}

