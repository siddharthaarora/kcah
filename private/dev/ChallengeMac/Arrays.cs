using System;
using System.Collections.Generic;

namespace Challenge
{
    public static class ArrayAlgos
    {
        public static int FindUniqueElement(List<int> a)
        {
            int xor = 0;

            foreach(var e in a)
            {
                xor ^= e;
            }

            return xor;
        }

        public static bool IsSumofPairsEqualToZero(List<int> A)
        {
            int i = 0;
            int j = A.Count-1;
            
            A.Sort();
            while (i < j)
            {
                if (A[i] + A[j] == 0)
                {
                    return true;
                }
                else if (A[i] + A[j] < 0)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }
            return false;
        }

        public static void Test_FindUniqueElement()
        {
            List<int> a = new List<int>() { 23, 34, 56, 21, 21, 56, 78, 23, 34, 99 };

            Console.WriteLine("Unique element in array is: " + FindUniqueElement(a).ToString());
        }

        public static void Test_IsSumofPairsEqualToZero()
        {
            List<int> A = new List<int>(){0, -1, 2, 3, 5};
            Console.WriteLine("The input array contains pair that sums to Zero: " + IsSumofPairsEqualToZero(A).ToString());
        }
    }
}