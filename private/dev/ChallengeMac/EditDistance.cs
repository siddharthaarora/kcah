// Given two strings str1 and str2 and below operations that can performed on str1. 
// Find minimum number of edits (operations) required to convert ‘str1’ into ‘str2’.

// Examples: 
// Input:   str1 = "geek", str2 = "gesek"
// Output:  1
// We can convert str1 into str2 by inserting a 's'.

// Input:   str1 = "cat", str2 = "cut"
// Output:  1
// We can convert str1 into str2 by replacing 'a' with 'u'.

// Input:   str1 = "sunday", str2 = "saturday"
// Output:  3
// Last three and first characters are same.  We basically
// need to convert "un" to "atur".  This can be done using
// below three operations. 
// Replace 'n' with 'r', insert t, insert a

using System;
using System.Collections.Generic;

namespace Challenge
{
    public static class EditDistance
    {
        public static int FindEditDistance(string a, string b)
        {
            return FindEditDistance(a.ToCharArray(), b.ToCharArray(), a.Length, b.Length);
        }

        private static int FindEditDistance(char[] a, char[] b, int m, int n)
        {
            int[,] t = new int[m+1,n+1];

            for(int i=0;i<=m;i++)
            {
                for(int j=0;j<=n;j++)
                {
                    Utilities.PrintMatrix<int>(t);
                    Console.WriteLine("..........................");
                    if (i == 0)
                    {
                        t[i,j] = j;
                    }
                    else if (j == 0)
                    {
                        t[i,j] = i;
                    }
                    else if (a[i-1] == b[j-1])
                    {
                        t[i,j] = t[i-1, j-1];
                    }
                    else
                    {
                        t[i,j] = 1 + Min(t[i-1,j], t[i,j-1], t[i-1, j-1]);
                    }
                }
            }
            Utilities.PrintMatrix<int>(t);
            return t[m,n];
        }

        private static int Min(int x, int y, int z)
        {
            return Math.Min(Math.Min(x,y), z);
        }

        public static void Test_EditDistance()
        {
            int d = FindEditDistance("geek", "geeks");
            Console.WriteLine("Edit distance: " + d.ToString());
        }
    }
}