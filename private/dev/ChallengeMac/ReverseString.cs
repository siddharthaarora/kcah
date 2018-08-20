// Reverse an array without affecting special characters
// Given a string, that contains special character together with alphabets (‘a’ to ‘z’ and ‘A’ to ‘Z’), reverse the string in a way that special characters are not affected.
// Examples:
// Input:   str = "a,b$c"
// Output:  str = "c,b$a"
// Note that $ and , are not moved anywhere.  
// Only subsequence "abc" is reversed

// Input:   str = "Ab,c,de!$"
// Output:  str = "ed,c,bA!$"

using System;
using System.Collections.Generic;

namespace Challenge
{
    public static class ReverseString
    {
        public static void ReverseStringWithSpecicalCharacters(char[] a)
        {
            List<char> sc = new List<char>(){',', '$'};
            int i=0, j=a.Length-1;

            if (a == null)
            { return; }
            int count = (a.Length/2);

            while(i < count || j > count)
            {
                if (sc.Contains(a[i]))
                {
                    i++;
                }
                else if (sc.Contains(a[j]))
                {
                    j--;
                }
                else
                {
                    char t = a[i];
                    a[i] = a[j];
                    a[j] = t;
                    i++;
                    j--;
                }
            }
        }

        public static void Test_ReverseStringWithSpecicalCharacters()
        {
            char[] s = "s$idar,o".ToCharArray();
            ReverseStringWithSpecicalCharacters(s);

            Console.WriteLine("Reversed string: " + new string(s));
        }
    }
}