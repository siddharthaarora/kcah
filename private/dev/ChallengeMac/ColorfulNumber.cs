//For Given Number N find if its COLORFUL number or not
//Return 0/1
//COLORFUL number:
//A number can be broken into different contiguous sub-subsequence parts.
//Suppose, a number 3245 can be broken into parts like 3 2 4 5 32 24 45 324 245. 
//And this number is a COLORFUL number, since product of every digit of a contiguous subsequence is different
//Example:
//N = 23
//2 3 23
//2 -> 2
//3 -> 3
//23 -> 6
//this number is a COLORFUL number since product of every digit of a sub-sequence are different.
//Output : 1

using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge
{
    public class ColorfulNumber
    {
        private static List<int> GetDigits(int n)
        {
            List<int> digits = new List<int>();

            int temp = n;
            while (temp > 0)
            {
                digits.Add(temp % 10);
                temp = temp / 10;
            }

            digits.Reverse();
            return digits;
        }

        public static int IsColorful(int n)
        {
            List<int> digits = GetDigits(n);

            HashSet<int> products = new HashSet<int>();

            int subSequenceCount = 1, subSequenceProduct = 1;

            while (subSequenceCount <= digits.Count)
            {
                for (int i = 0; i < digits.Count; i++)
                {
                    if (subSequenceCount+i > digits.Count)
                    {
                        break;
                    }

                    for (int j = i; j < subSequenceCount+i; j++)
                    {
                        subSequenceProduct = subSequenceProduct * digits[j];
                    }

                    if (products.Contains(subSequenceProduct))
                    {
                        return 0;
                    }
                    else
                    {
                        products.Add(subSequenceProduct);
                    }

                    subSequenceProduct = 1;
                }
                subSequenceCount++;
            }
            return 1;
        }

        public static void Test_IsColorful()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (IsColorful(n) == 1)
            {
                Console.WriteLine(n.ToString() + " is COLORFUL!");
            }
            else
            {
                Console.WriteLine(n.ToString() + " is NOT colorful!!");
            }
        }
    }
}
