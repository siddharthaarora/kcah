using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge
{
    class Program
    {
        static void Main(String[] args)
        {
            //List<int> list = new List<int>();
            //list.Add(1);
            //int single = ArrayManipulation.SingleNumber(list);
            //Console.WriteLine(ArrayManipulation.MajorityElement(list));

            //ArrayList a = new ArrayList() { 0, 1, 2, 1, 0, 2, 2, 2, 1, 3 };
            //Console.WriteLine(ArrayManipulation.RemoveElement(a, 2));

            //Console.WriteLine(Utils.IsPrime(23));
            //int[] primes = new int[] { 3, 5, 7 };

            //List<int> a = new List<int> { 19, 11, 85, 100, 44, 3, 32, 96, 72, 93, 76, 67, 93, 63, 5, 10, 45, 99, 35, 13 };
            //int diffk2 = ArrayManipulation.DiffK2(a, 60);
            //Console.WriteLine(diffk2);

            //****Bit Manipulation****//
            //BitManipulation.CountNumberOfSetBits2(Int32.MaxValue);
            //BitManipulation.GetBinaryString(5);
            //BitManipulation.GetBinaryString((int)BitManipulation.ReverseBits(5));

            //****Tree****//
            //TreeNode root = new TreeNode(6);
            //root.Left = new TreeNode(4);
            //root.Right = new TreeNode(9);
            //root.Left.Left = new TreeNode(3);
            //root.Left.Right = new TreeNode(5);

            //Console.Write("Level Order Traversal: ");
            //TreeTraversal.LevelOrderTraversal(root);
            //Console.WriteLine();

            //Console.Write("In Order Traversal: ");
            //TreeTraversal.PreOrderTraversal(root);
            //Console.WriteLine();
            ////Console.WriteLine(TreeTraversal.IsSymmetric(root));

            //List<int> nodes = null;
            //TreeTraversal.Serialize(root, ref nodes);
            //Utils.PrintList(nodes);

            //TreeNode newRoot = null;
            //TreeTraversal.Deserialize(nodes, ref newRoot);
            //Console.Write("In Order Traversal: ");
            //TreeTraversal.PreOrderTraversal(newRoot);
            //Console.WriteLine();

            //****Sorting algos****//
            //int[] a = new int[] { 3, 7, 8, 5, 2, 1, 9, 5, 4 };
            //Console.WriteLine(String.Join(" ", a));

            //Sort.QuickSort(a, 0, a.Length - 1);

            //int number = Convert.ToInt32(Console.ReadLine());
            //int reversedNumber = Utils.ReverseDigits(number);
            //Console.WriteLine("Original number: " + number.ToString() + "; Reversed number: " + reversedNumber.ToString());
            //Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Enter: a Excel column name: ");
                string columnName = Console.ReadLine().ToString();
                int colNumber = ArrayManipulation.ExcelColumnNameToNumber(columnName);
                Console.WriteLine("ColumnName: " + columnName + " ColumnNumber: " + colNumber.ToString());
            }
        }
    }
}
