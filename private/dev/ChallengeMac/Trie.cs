using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Challenge
{
    public class Trie
    {
        public class Node
        {
            public string Label {get; set;}
            public Dictionary<char, Node> Children = new Dictionary<char, Node>();
        }

        public Node Root {get;}

        public Trie()
        {
            Root = new Node();
        }
        public void Insert(string s)
        {
            var cur = Root;
            for(int i = 0;i<s.Length;i++)
            {
                var c = s[i];

                if (!cur.Children.ContainsKey(c))
                {
                    var n = new Node() {Label = s};
                    cur.Children.Add(c, n);
                    return;
                }
                cur = cur.Children[c];
            }
        }

        public bool Find(string s)
        {
            var n = FindNode(s);
            
            if (n == null) 
                return false;

            foreach(var n2 in VisitNode(n))
            {
                Console.WriteLine(n2.Label);
            }

            return true;
        }

        private Node FindNode(string s)
        {
            Node cur = Root;

            for (int i=0; i<s.Length;i++)
            {
                var c = s[i];

                while (cur.Children.ContainsKey(c))
                {
                    cur = cur.Children[c];
                }
            }

            if (cur.Label == s)
            {
                return cur;
            }
            else
            {
                return null;
            }
        }

        private IEnumerable<Node> VisitNode(Node n)
        {
            foreach (var n1 in n.Children.Values)
            {
                foreach(var n2 in VisitNode(n1))
                {
                    yield return n2;
                }
            }
            yield return n;
        }

        public static void Test_TrieFindSubstring()
        {
            Trie t = new Trie();
            t.Insert("banana");
            t.Insert("bat");
        }
    }
}