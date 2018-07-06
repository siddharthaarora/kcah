using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge
{
    public class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;
        public TreeNode(int x)
        {
            this.Value = x;
            this.Left = this.Right = null;
        }
    }

    public static class TreeTraversal
    {
        public static void LevelOrderTraversal(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                TreeNode node = q.Dequeue();
                Console.Write(node.Value);
                Console.Write(" ");

                if (node.Left != null)
                {
                    q.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }
        }

        public static void Serialize(TreeNode n, ref List<int> l)
        {
            if (n == null)
            {
                return;
            }

            if (l == null)
            {
                l = new List<int>();
            }

            l.Add(n.Value);

            if (n.Left != null)
            {
                Serialize(n.Left, ref l);
            }
            else
            {
                l.Add(-1);
            }
            
            if (n.Right != null)
            {
                Serialize(n.Right, ref l);
            }
            else
            {
                l.Add(-1);
            }
        }

        public static void Deserialize(List<int> a, ref TreeNode root, int index = 0)
        {
            if (a[index] == -1 || index >= a.Count)
            {
                return;
            }

            root = new TreeNode(a[index]);

            Deserialize(a, ref root.Left, ++index);
            Deserialize(a, ref root.Right, ++index);

            return;
        }

        public static void PreOrderTraversal(TreeNode root)
        {
            if (root == null) return;

            Console.Write(root.Value);
            Console.Write(" ");

            if (root.Left != null)
            {
                PreOrderTraversal(root.Left);
            }
            else
            {
                Console.Write("-1 ");
            }

            if (root.Right != null)
            {
                PreOrderTraversal(root.Right);
            }
            else
            {
                Console.Write("-1 ");
            }

        }

        public static void BalanceBinaryTree(TreeNode node)
        {

        }

        public static int FindLongestPath(TreeNode root)
        {
            int pathSize = 0;

            return pathSize;
        }

        public static int IsSymmetric(TreeNode A)
        {
            if (A == null) return 0;

            return (IsSame(A.Left, A.Right)) ? 1 : 0;
        }

        public static bool IsSame(TreeNode node1, TreeNode node2)
        {
            if (node1 == null && node2 == null)
            {
                return true;
            }

            if (node1 == null || node2 == null)
            {
                return false;
            }

            if (node1.Value != node2.Value)
            {
                return false;
            }

            return IsSame(node1.Left, node2.Right) || IsSame(node1.Right, node2.Left);
        }


    }
}