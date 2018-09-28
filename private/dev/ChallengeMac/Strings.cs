using System;
using System.Collections;
using System.Collections.Generic;

namespace Challenge
{
    public static class StringAlgos
    {
        // Given two strings, the task is to check whether these strings are meta strings or not. 
        // Meta strings are the strings which can be made equal by exactly one swap in any of the strings. 
        // Equal string are not considered here as Meta strings.
        // Examples:
        // Input : A = "geeks" 
        //         B = "keegs"
        // Output : 1
        // By just swapping 'k' and 'g' in any of string, 
        // both will become same.

        // Input : A = "rsting"
        //         B = "string
        // Output : 0
        public static bool IsMetaString(string a, string b)
        {
            if ((string.IsNullOrEmpty(a) || 
            string.IsNullOrEmpty(b) || 
            a.Length != b.Length || 
            string.Equals(a, b))
            )
            {
                return false;
            }

            int count = 0;
            for(int i=0;i<a.Length;i++)
            {
                if (a[i] != b[i])
                {
                    count++;
                }
                if (count > 2)
                {
                    return false;
                }
            }

            return true;
        }

        public static void Test_IsMetaString()
        {
            string a = "string";
            string b = "rsting";

            Console.WriteLine("The two strings - " + a + " and " + b + " are meta strings: " + IsMetaString(a, b).ToString());
        }
    }

}