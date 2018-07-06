//Given a sorted array of integers, find the starting and ending position of a given target value.
//Your algorithm’s runtime complexity must be in the order of O(log n).
//If the target is not found in the array, return [-1, -1].
//Example:
//Given[5, 7, 7, 8, 8, 10]
//and target value 8,
//return [3, 4].

using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge
{
    public static class SearchRange
    {
        public static List<int> FindIndexRangeForNumber(List<int> a, int n)
        {
            List<int> res = new List<int>();

            int start = 0;
            int end = a.Count-1;

            int index = BinarySearch(a, n, start, end);

            if (index == -1)
            {
                res.Add(-1);
                res.Add(-1);
                return res;
            }

            start = end = index;

            while (start-1 >= 0 && a[start-1] == n)
            {
                --start;
            }

            while (end+1 <= a.Count - 1 && a[end+1] == n)
            {
                ++end;
            }

            for(int i=start; i<=end; i++)
            {
                res.Add(i);
            }
            return res;
        }

        public static int BinarySearch(List<int> a, int n, int start, int end)
        {
            if (n == a[start])
            { return start; }

            if (n == a[end])
            { return end; }

            if (n >= a[start] && n <= a[end / 2])
            {
                return BinarySearch(a, n, start, end / 2);
            }
            else if (n >= a[(end / 2)+1] && n <= a[end])
            {
                return BinarySearch(a, n, (end / 2)+1, end);
            }

            return -1;
        }

        public static void Test_FindIndexRangeForNumber()
        {
            List<int> a = new List<int>() { 1,1 };

            List<int> rest = FindIndexRangeForNumber(a, 1);
        }

        public static void Test_BinarySearch()
        {
            List<int> a = new List<int>() { 5, 7, 7, 8, 8, 10 };
            int index = BinarySearch(a, 7, 0, a.Count-1);
        }
    }
}
