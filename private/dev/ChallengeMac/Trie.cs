using System;
using System.Collections.Generic;
using System.Text;
//https://visualstudiomagazine.com/Articles/2015/10/20/Text-Pattern-Search-Trie-Class-NET.aspx?Page=1
namespace Challenge
{
    public class Trie
    {
        private TrieNode root;

        public void InsertRange(List<string> list)
        {
            foreach(var s in list)
            {
                Insert(s);
            }
        }
        public void Insert(string s)
        {
            root = Insert(root, s, 0);
        }

        public TrieNode Insert(TrieNode n, string s, int index)
        {
            if (index == s.Length)
            {
                return n;
            }

            char c = s[index];
            if (n == null)
            {
                n = new TrieNode(c);
            }

            if (c < n.Value)
            {
                n.Left = Insert(n.Left, s, index);
            }
            else if (c > n.Value)
            {
                n.Right = Insert(n.Right, s, index);
            }
            else
            {
                n.Mid = Insert(n.Mid, s, index + 1);
                n.Frequency += 1;
            }

            return n;
        }

        public string Prefix(string s)
        {
            StringBuilder sb = new StringBuilder();
            return Prefix(root, s, 0, sb);
        }

        public string Prefix(TrieNode n, string s, int index, StringBuilder sb)
        {
            char c = s[index];

            if (c < n.Value)
            {
                return Prefix(n.Left, s, index, sb);
            }
            else if (c > n.Value)
            {
                return Prefix(n.Right, s, index, sb);
            }
            else if (n.Frequency == 1)
            {
                sb.Append(n.Value);
                return sb.ToString();
            }
            else
            {
                sb.Append(n.Value);
                return Prefix(n.Mid, s, index + 1, sb);
            }

        }
    }


    public class TrieNode
    {
        public char Value { get; set; }

        public int Frequency { get; set; }

        public TrieNode Left { get; set; }

        public TrieNode Mid { get; set; }

        public TrieNode Right { get; set; }

        public TrieNode(char value)
        {
            this.Value = value;
            this.Frequency = 0;
        }
    }
}