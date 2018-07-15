//Implemention and computational analysis of various sorting algorithms

using System;
using System.Collections;
using System.Collections.Generic;

namespace Challenge
{
    public static class Sort
    {
        public static void SelectionSort(List<int> a)
        {
            if (a == null)
            {
                return;
            }

            for (int i=0;i<a.Count;i++)
            {
                int min = a[i];

                for (int j=i;j<a.Count;j++)
                {
                    if (a[i] > a[j])
                    {
                        Swap(a, i, j);
                    }
                }
                Utilities.PrintList(a);
            }
        }

        public static void InsertionSort(List<int> a)
        {
            if (a == null)
            {
                return;
            }

            for(int i=1;i<a.Count;i++)
            {
                int j=i;
                while ((j >0) && a[j] < a[j-1])
                {
                    Swap(a, j, j-1);
                    j = j-1;
                }
                Utilities.PrintList(a);
            }
        }
        private static void Swap(List<int> a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        public static void Test_SelectionSort()
        {
            Console.WriteLine("Testing Selection Sort - ");
            List<int> a = new List<int>{3, 5, 9, 1, 4, 6, 2};
            Utilities.PrintList(a);
            Sort.SelectionSort(a);
            Utilities.PrintList(a);
        }
        
        public static void Test_InsertionSort()
        {
            Console.WriteLine("Testing Insertion Sort - ");
            List<int> a = new List<int>{3, 5, 9, 1, 4, 6, 2};
            Utilities.PrintList(a);
            Sort.InsertionSort(a);
            Utilities.PrintList(a);
        }
    }
}