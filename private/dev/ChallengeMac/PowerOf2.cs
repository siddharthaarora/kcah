//Find if Given number is power of 2 or not.
//More specifically, find if given number can be expressed as 2^k where k >= 1.
//Input:
//number length can be more than 64, which mean number can be greater than 2 ^ 64 (out of long range)
//Output:
//return 1 if the number is a power of 2 else return 0

//Example:
//Input : 128
//Output : 1

using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge
{
    public class PowerOf2
    {
        public static int IsPowerof2(string n)
        {
            if (n.Length == 0)
            {
                return 0;
            }
            else if (n.Length != 0 && (n == "0" || n == "1"))
            {
                return 0;
            }

            string divident = n;
            StringBuilder dividentPart = new StringBuilder();
            StringBuilder quotient = new StringBuilder(divident);

            while (divident.Length > 0)
            {
                if (quotient[0] == '0')
                {
                    quotient.Remove(0, 1);
                }
                divident = quotient.ToString();
                quotient.Remove(0, quotient.Length);

                if (divident.Length == 1 && divident == "1")
                {
                    break;
                }

                for (int i = 0; i < divident.Length; i++)
                {

                    if (divident[i] == '0')
                    {
                        quotient.Append("0");
                    }

                    dividentPart.Append(divident[i]);
                    if (Convert.ToInt32(dividentPart.ToString()) >= 2)
                    {
                        quotient.Append(Convert.ToInt32(dividentPart.ToString()) / 2);
                        if (Convert.ToInt32(dividentPart.ToString()) % 2 != 0)
                        {
                            dividentPart.Remove(0, dividentPart.Length).Append("1");
                        }
                        else
                        {
                            dividentPart.Remove(0, dividentPart.Length);
                        }
                    }

                    if (dividentPart.Length > 0 && Convert.ToInt32(dividentPart.ToString()) == 1 && i == divident.Length-1)
                    {
                        return 0;
                    }
                }
                dividentPart.Remove(0, dividentPart.Length);
            }

            return 1;
        }

        public static void Test_IsPowerOf2()
        {
            string n = Console.ReadLine();
            if (PowerOf2.IsPowerof2(n) == 1)
            {
                Console.WriteLine(n + " is a power of 2!");
            }
            else
            {
                Console.WriteLine(n + " is NOT a power of 2!");
            }

        }
    }

}
