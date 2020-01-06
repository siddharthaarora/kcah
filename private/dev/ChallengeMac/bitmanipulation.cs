
using System;
using System.Text;

namespace Kcah
{
    public static class BitManipulation
    {
        public static void InsertNBits(int n, int m, int i, int j)
        {
            PrintIntBits(n);
            PrintIntBits(m);
            
            Console.WriteLine("Shifting m, j times... ");
            m = m << j;
            PrintIntBits(m);
        }

        public static void PrintIntBits(int n)
        {
            Console.Write(n + ": ");
            StringBuilder sb = new StringBuilder();
            while (n > 0)
            {
                if ((n & 0x1) == 1)
                { 
                    sb.Append("1"); 
                }
                else
                    sb.Append("0");
                n = n >> 1;
            }

            int i = 0;
            while (i < (32 - sb.Capacity))
            { 
                sb.Append("0"); 
                i++;
            }            
            
            for(int j=sb.Length-1; j >=0; j--)
            { 
                Console.Write(sb.ToString()[j]); 
                if (j % 4 == 0)
                { Console.Write(" "); }
            }
            Console.WriteLine();
        }

        public static void Test_InsertNBits()
        {
            InsertNBits(27, 5, 8, 4);
        }
    }
}