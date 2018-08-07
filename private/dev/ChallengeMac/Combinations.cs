// Given two integers n and k, return all possible combinations of k numbers out of 1 2 3 ... n.
// Make sure the combinations are sorted.
// To elaborate,
// 1. Within every entry, elements should be sorted. [1, 4] is a valid entry while [4, 1] is not.
// 2. Entries should be sorted within themselves.
// Example :
// If n = 4 and k = 2, a solution is:
// [
//   [1,2],
//   [1,3],
//   [1,4],
//   [2,3],
//   [2,4],
//   [3,4],
// ]

using System;
using System.Collections.Generic;

namespace Challenge
{
    public static class Combinations
    {
        public static List<List<int>> GenerateCombinations(int n, int k)
        {            
            List<List<int>> res = new List<List<int>>();
            int[] t = new int[k];
            List<int> input = new List<int>();

            for(int i=1;i<=n;i++)
            { input.Add(i); }

            Combine(input, k, 0, 0, t, res);
            return res;
        }

        public static void Combine(List<int> input, int k, int index, int i, int[] t, List<List<int>> res)
        {
            if (k==0)
            { return; }

            if(index == k)
            {
                res.Add(new List<int>(t));
                return;
            }

            if (i >= input.Count)
            { return; }

            t[index] = input[i];

            Combine(input, k, index+1, i+1, t, res);

            Combine(input, k, index, i+1, t, res);
        }

        public static void Test_GenerateCombinations()
        {
            List<List<int>> c = GenerateCombinations(5, 3);

            foreach(var l in c)
            {
                Utilities.PrintList(l);
            }
        }
    }
}