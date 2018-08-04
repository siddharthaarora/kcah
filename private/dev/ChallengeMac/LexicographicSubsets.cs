// Given a collection of integers that might contain duplicates, S, return all possible subsets.
// Note:
// Elements in a subset must be in non-descending order.
// The solution set must not contain duplicate subsets.
// The subsets must be sorted lexicographically.
// Example :
// If S = [1,2,2], the solution is:

// [
// [],
// [1],
// [1,2],
// [1,2,2],
// [2],
// [2, 2]
// ]

using System;
using System.Collections.Generic;

namespace Challenge
{
    public static class LexicographicSubset
    {
        public static List<List<int>> GetLexicographicSubset(List<int> A)
        {
            List<List<int>> res = new List<List<int>>();
            HashSet<int> s = new HashSet<int>();

            A.Sort();
            
            int counter = 1;

            if (A == null)
            {
                return res;
            }

            res.Add(new List<int>(){});

            for(int i=0; i<A.Count;i++)
            {
                if (!s.Contains(A[i]))
                {
                    while(counter <= A.Count-i)
                    {
                        res.Add(A.GetRange(i, counter));
                        counter++;
                    }
                    counter = 1;
                    s.Add(A[i]);
                }
            }

            return res;
        }

        public static void Test_GetLexographicSubset()
        {
            List<List<int>> res = GetLexicographicSubset(new List<int>() {2,2,1});

            foreach(var s in res)
            {
                Utilities.PrintList(s);
            }
        }
    }
}