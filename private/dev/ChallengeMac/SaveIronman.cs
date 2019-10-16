// You are given a string S containing alphanumeric characters. Find out whether the string is a palindrome or not.
// Note: Consider alphabets and numbers only for palindrome check. Ignore symbols and whitespaces.
// Example:
// I am :IronnorI Ma, i --> Yes
// Ab?/Ba --> Yes

using System;

namespace Challenge
{
    public static class SaveIronman
    {
        public static bool IsPalindrome(string s)
        {
            bool res = false;
            // a-z: 97-122; A-Z: 65-90; 0-9: 48-57

            int sum = 0;

            if (s.Length % 2 == 1)
            {
                sum = s[s.Length/2];
            }

            s = s.ToLower();
            int count = 0;
            for (int i=0; i<s.Length/2; i++)
            {
                int a = Convert.ToInt32(s[i]);
                if ( (a >= 48 && a <= 57) || (a >= 65 && a <= 90) || (a >= 97 && a <= 122))
                {
                    count += a;
                } 

                a = Convert.ToInt32(s[s.Length-i-1]);
                if ( (a >= 48 && a <= 57) || (a >= 65 && a <= 90) || (a >= 97 && a <= 122))
                {
                    count -= a;
                }
            }

            if (sum == count)
            {
                res = true;
            }

            return res;
        }

        public static void Test_IsPalindrome()
        {
            string s = "I am :IronnorI Ma, i";

            if (IsPalindrome(s))
            {
                Console.WriteLine(s + " is a palindrome!");
            }
            else
            {
                Console.WriteLine(s + " is NOT a palindrome!");
            }
        }
    }
}