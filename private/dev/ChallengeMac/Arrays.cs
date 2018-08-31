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

        public static void Test_FindUniqueElement()
        {
            List<int> a = new List<int>() { 23, 34, 56, 21, 21, 56, 78, 23, 34, 99 };

            Console.WriteLine("Unique element in array is: " + FindUniqueElement(a).ToString());
        }
    }
}