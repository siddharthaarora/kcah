// The Longest Increasing Subsequence (LIS) problem is to find the length of the 
// longest subsequence of a given sequence such that all elements of the subsequence 
// are sorted in increasing order. For example, 
// // Input  : arr[] = {3, 10, 2, 1, 20}
// Output : Length of LIS = 3
// The longest increasing subsequence is 3, 10, 20

// Input  : arr[] = {3, 2}
// Output : Length of LIS = 1
// The longest increasing subsequences are {3} and {2}

// Input : arr[] = {50, 3, 10, 7, 40, 80}
// Output : Length of LIS = 4
// The longest increasing subsequence is {3, 7, 40, 80}

using System;
using System.Collections.Generic;

namespace Challenge
{
    public static class LongestIncreasingSubsequence
    {
        public static int FindLongestIncreasingSubsequence(List<int> a)
        {
            List<List<int>> res = new List<List<int>>();
            int max = 0, maxIndex = 0;

            if (a == null || a.Count == 0)
            { return 0; }
            else if (a.Count == 1)
            { return 1; }

            for(int i=0;i<a.Count;i++)
            {
                List<int> l = new List<int>();
                l.Add(a[i]);
                for(int j=i+1;j<a.Count;j++)
                {
                    if (a[j] > a[i])
                    {
                        bool isMax = true;
                        for(int k=l.Count-1;k>=0;k--)
                        {
                            if(a[j] < l[k])
                            {
                                isMax = false;
                                break;
                            }
                        }
                        if (isMax)
                        { l.Add(a[j]); }
                    }
                }
                res.Add(l);
            }

            for(int i=0;i<res.Count;i++)
            {
                if (max < res[i].Count)
                {
                    max = res[i].Count;
                    maxIndex = i;
                }
            }

            Console.WriteLine("Longest Increasing Subsequence for input: ");
            Utilities.PrintList(a);
            Console.WriteLine( "is: " + max.ToString());
            Console.WriteLine("and the longest increasing subsequence is: ");
            Utilities.PrintList(res[maxIndex]);

            return maxIndex;
        }

        public static void Test_FindLongestIncreasingSubsequence()
        {
            List<int> l = new List<int>(){3, 10, 2, 1, 20, 15, 21, 17};
            FindLongestIncreasingSubsequence(l);
        }
    }
}