// The gray code is a binary numeral system where two successive values differ in only one bit.
// Given a non-negative integer n representing the total number of bits in the code, print the sequence of gray code. 
//A gray code sequence must begin with 0.
// For example, given n = 2, return [0,1,3,2]. Its gray code sequence is:
// 00 - 0
// 01 - 1
// 11 - 3
// 10 - 2
// There might be multiple gray code sequences possible for a given n.
// Return any such sequence.

using System;
using System.Collections.Generic;

namespace Challenge
{
    public static class GrayCode
    {
        public static List<int> GenerateGrayCode(int n)
        {
            List<int> res = new List<int>();

            if (n == 0)
            {
                res.Add(0);
                return res;
            }
            else
            {
                List<int> prev = GenerateGrayCode(n-1);

                res.AddRange(prev);

                for(int i=prev.Count-1;i>=0;i--)
                {
                    res.Add(prev[i] + (int)Math.Pow(2, n-1));
                }
            }
            return res;
        }

        public static void Test_GenerateGrayCode()
        {
            Utilities.PrintList(GenerateGrayCode(8));
        }
    }
}