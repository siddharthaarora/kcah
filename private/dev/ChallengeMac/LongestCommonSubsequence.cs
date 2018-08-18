//  Given two sequences, find the length of longest subsequence present in both of them. A subsequence is a sequence that appears in the same relative order, but not necessarily contiguous. For example, “abc”, “abg”, “bdf”, “aeg”, ‘”acefg”, .. etc are subsequences of “abcdefg”. So a string of length n has 2^n different possible subsequences.
// It is a classic computer science problem, the basis of diff (a file comparison program that outputs the differences between two files), and has applications in bioinformatics.
// Examples:
// LCS for input Sequences “ABCDGH” and “AEDFHR” is “ADH” of length 3.
// LCS for input Sequences “AGGTAB” and “GXTXAYB” is “GTAB” of length 4.

using System;

namespace Challenge
{
    public static class LongestCommonSubsequence
    {
        public static int FindLengthofLongestCommonSubsequence(string a, string b)
        {
            if (a == null || b == null || a.Length == 0 || b.Length == 0)
            {
                return 0;
            }

            return FindLCS_2(a, b, a.Length-1, b.Length-1);
        }

        public static void Test_FindLengthofLongestCommonSubsequence()
        {
            String s1 = "AGGTAB";
            String s2 = "AGXTXAYB";
            int l = FindLengthofLongestCommonSubsequence(s1, s2);

            Console.WriteLine("Length of Longest Common Subsequence for strings " + s1 + " and " + s2 + " is " + l.ToString());            
        }

        private static int FindLCS_1(string a, string b, int i, int j)
        {
            if (i == 0 || j == 0)
            {
                return 0;
            }

            if (a[i] == b[j])
            {
                return 1 + FindLCS_1(a, b, i-1, j-1);
            }
            else
            {
                return Max(FindLCS_1(a,b,i,j-1), FindLCS_1(a,b,i-1,j));
            }
        }

        private static int FindLCS_2(string a, string b, int m, int n)
        {
            int[,] l = new int[m+1,n+1];

            for(int i=0; i<=m; i++)
            {
                for(int j=0; j<=n; j++)
                {
                    if (i ==0 || j == 0)
                    {
                        l[i,j] = 0;
                    }
                    else if (a[i-1] == b[j-1])
                    {
                        l[i,j] = l[i-1, j-1] + 1;
                    }
                    else
                    {
                        l[i,j] = Max(l[i-1,j], l[i,j-1]);
                    }
                }
            }
            Utilities.PrintMatrix<int>(l);

            return l[m,n];
        }

        private static int Max(int i, int j)
        {
            return (i > j)? i : j;
        }
    }
}