using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge
{
    public static class TreeOperations
    {
        private static BinarySearchTree Tree = new BinarySearchTree();

        public static void AddNodesToBST(List<int> nodes)
        {
            if (nodes != null && nodes.Count > 0)
            {
                foreach (var n in nodes)
                {
                    Tree.Add(n);
                }
            }
        }

        public static void Test_AddNodesToBST()
        {
            List<int> a = new List<int> { 5, 4, 7, 2, 6, 1, 3, 8, 9};

            Console.WriteLine("Input: ");
            foreach (var n in a)
            {
                Console.Write(n);
                Console.Write(",");
            }

            AddNodesToBST(a);

            Console.WriteLine();

            List<List<int>> nodes = Tree.Traverse();

            Console.WriteLine("Output - Level Order: ");
            PrintTreeTraversal(nodes);

            nodes = Tree.Traverse(BinarySearchTree.TraversalOrder.LevelOrderZigZag);

            Console.WriteLine("Output - Level Order ZigZag: ");
            PrintTreeTraversal(nodes);
        }

        //Given a binary tree containing digits from 0-9 only, each root-to-leaf path could represent a number.
        //An example is the root-to-leaf path 1->2->3 which represents the number 123.
        //Find the total sum of all root-to-leaf numbers % 1003.
        //Example :
        //    1
        //   / \
        //  2   3
        //The root-to-leaf path 1->2 represents the number 12.
        //The root-to-leaf path 1->3 represents the number 13.
        //Return the sum = (12 + 13) % 1003 = 25 % 1003 = 25.
        public static int FindSumToLeaf()
        {
            List<int> a = new List<int> { 5, 4, 7, 2, 6, 1, 3, 8, 9 };

            Console.WriteLine("Input: ");
            foreach (var n in a)
            {
                Console.Write(n);
                Console.Write(",");
            }

            AddNodesToBST(a);

            Console.WriteLine();

            List<List<int>> nodes = FindAllPathsToLeaf(Tree.Root);

            Console.WriteLine("Output - All Paths: ");
            PrintTreeTraversal(nodes);

            int sum = 0;
            foreach (var path in nodes)
            {
                int t = 0;
                for(int i=0;i<path.Count;i++)
                {
                    t += path[i] * Convert.ToInt32(Math.Pow(10, path.Count - 1 - i));
                }
                t %= 1003;
                sum += t;
            }
            return sum % 1003;
        }
        private static List<List<int>> FindAllPathsToLeaf(TreeNode node)
        {
            List<List<int>> allPaths = new List<List<int>>();

            FindAllPathsToLeaf(node, allPaths, new List<int>());

            return allPaths;
        }

        private static void FindAllPathsToLeaf(TreeNode node, List<List<int>> allpaths, List<int> thisPath)
        {
            thisPath.Add(node.Value);

            if (node.Left == null && node.Right == null)
            {
                allpaths.Add(new List<int>(thisPath));
            }

            if (node.Left != null)
            {
                FindAllPathsToLeaf(node.Left, allpaths, thisPath);
            }

            if (node.Right != null)
            {
                FindAllPathsToLeaf(node.Right, allpaths, thisPath);
            }

            thisPath.Remove(node.Value);
        }

        private static void PrintTreeTraversal(List<List<int>> nodes)
        {
            Console.WriteLine("{ ");
            foreach (var l in nodes)
            {
                Console.Write("[");
                foreach (var n in l)
                {
                    Console.Write(n);
                    Console.Write(",");
                }
                Console.WriteLine("]");
            }
            Console.WriteLine("} ");
        }
    }
}
