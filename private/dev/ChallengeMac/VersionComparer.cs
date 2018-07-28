// Compare two version numbers version1 and version2.

// If version1 > version2 return 1,
// If version1 < version2 return -1,
// otherwise return 0.
// You may assume that the version strings are non-empty and contain only digits and the . character.
// The . character does not represent a decimal point and is used to separate number sequences.
// For instance, 2.5 is not "two and a half" or "half way to version three", it is the fifth second-level revision of the second first-level revision.

// Here is an example of version numbers ordering:

// 0.1 < 1.1 < 1.2 < 1.13 < 1.13.4

// Algo
// 1. Split both the versions on "."
// 2. Iterate over both the arrays, left to right
// 3. Convert each element in the array to float - a[i] / 10^i 
// 4. And, then compare the corresponding elements from both arrays
// 5. Cases:
//    a. 1.0 < 2.0
//    b. 1.0 < 1.1.0
//    c. 1.0 < 1.0.1
// Complexity - O(n)

using System;

namespace Challenge
{
    public static class VersionComparer
    {
        public static int CopareVersion(string a, string b)
        {
            int res = 0;

            if ((string.IsNullOrEmpty(a)) || string.IsNullOrEmpty(b))
            { return res; }

            string[] v1 = a.Split('.'); 
            string[] v2 = b.Split('.');
            int len = v1.Length > v2.Length ? v1.Length : v2.Length;

            for(int i=0; i<len;i++)
            {
                double ver1 = 0.0, ver2 = 0.0;
                if (i < v1.Length)
                {
                    ver1 = double.Parse(v1[i]) * Math.Pow(10, i);
                }

                if (i < v2.Length)
                {
                    ver2 = double.Parse(v2[i]) * Math.Pow(10, i);
                }

                if (ver1 > ver2)
                {
                    res = 1;
                }
                else if (ver2 > ver1)
                {
                    res = -1;
                }

                if (res != 0)
                {
                    break;
                }

            }
            return res;
        }

        public static void Test_CompareVersion()
        {
            string v1 = "1.2.1.123"; //Console.ReadLine();
            string v2 = "1.3"; //Console.ReadLine();

            int res = VersionComparer.CopareVersion(v1, v2);

            Console.WriteLine("Result: " + res);
        }
    }
}