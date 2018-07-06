using System;
using System.Collections.Generic;

namespace Challenge
{
    public static class OldTree
    {
        public static void TestGreaterTree()
        {
            OldTreeNode root = GenerateSampleBST();
            root.PrintTree();

            //LeetCode.ConvertBST(root);

            root.PrintTree();
        }

        public static void TestGreaterBSTFromSortedArray()
        {
            List<int> a = new List<int>{-10,-3,0,5,9};
            OldTreeNode root = GenerateSampleBST();
            root.PrintTree();

            //LeetCode.ConvertBST(root);

            root.PrintTree();
        }
        public static void TestLongestUnivaluePath()
        {
            OldTreeNode root = GenerateSampleBST();
            Console.WriteLine("Longest universl path: " + LeetCode.FindLongestUnivaluePath(root).ToString());
        }

        public static void TestPlus1()
        {
            List<int> A = new List<int>{1,9,9, 1};
            Console.Write("Input: ");
            PrintList(A);
            
            List<int> B = CodeLab.Plus1(A);
            Console.Write("Output: ");
            PrintList(B);
        }

        public static OldTreeNode GenerateSampleBST()
        {
            OldTreeNode root = new OldTreeNode(6);
            root.Insert(4);
            root.Insert(5);
            root.Insert(9);
            root.Insert(3);
            root.Insert(1);

            return root;
        }

        public static OldTreeNode GenerateBSTFromSortedArray(List<int> a)
        {
                // count = len(a)
                // mid = int(count / 2)
                // root.Insert(a[mid])
                // left = mid - 1
                // right = mid + 1
                // while(True):
                //     if (left < 0 and right > count-1):
                //         return
                //     if (left >= 0):
                //         root.Insert(a[left])
                //     if (right <= count -1):
                //         root.Insert(a[right])
                //     left -= 1
                //     right += 1

                int count = a.Count;
                int mid = count / 2;
                OldTreeNode root = new OldTreeNode(a[mid]);
                int left = mid - 1;
                int right = mid + 1;

                while(true)
                {
                    if (left < 0 && right > count - 1)
                    {
                        return root;
                    }
                    if (left >= 0)
                    {
                        root.Insert(a[left]);
                    }
                    if (right <= count - 1)
                    {
                        root.Insert(a[right]);
                    }
                    left--;
                    right++;
                }
        }

        public static void PrintList(List<int> A)
        {
            Console.Write("[");
            for(int i = 0; i<A.Count;i++)
            {
                Console.Write(A[i]);
                Console.Write(",");
            }
            Console.WriteLine("]");
        }
    }   
}