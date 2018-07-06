using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge
{
    public static class BitManipulation
    {
        public static void CountNumberOfSetBits(int input)
        {
            int count = 0, number = input;

            Console.WriteLine("Input: " + GetBinaryString(input));

            do
            {
                Console.WriteLine("Count: " + count);
                Console.WriteLine("Number: " + GetBinaryString(number));

                count += number % 2;
                number = number / 2;
            } while (number > 0);

            Console.WriteLine("Number of Ones in {0}: {1}", input, count);
        }

        public static void CountNumberOfSetBits2(int input)
        {
            int count = 0, n = input;
            Console.WriteLine("Input: " + GetBinaryString(input));

            do
            {
                if ((n & 1) == 1) count++;
                n = n >> 1;
                Console.WriteLine("Number: {0}, Binary:{1}", n, GetBinaryString(n));
            } while (n > 0);

            Console.WriteLine("Number of Ones in {0}: {1}", input, count);
        }

        public static UInt32 ReverseBits(UInt32 a)
        {
            UInt32 r = 0;

            for (int i = 0; i < 32; i++)
            {
                UInt32 t = a & 1;

                if (t == 0)
                {
                    r = r >> 1;
                }
                else
                {
                    r = r | (UInt32.MaxValue << 31);
                }
                a = a >> 1;
            }
            return r;
        }

        public static string GetBinaryString(int n, int groupSize = 4)
        {
            int number = n;
            StringBuilder sb = new StringBuilder();

            while (n > 0)
            {
                if ((n & 1) == 1)
                {
                    sb.Append("1");
                }
                else
                {
                    sb.Append("0");
                }
                n = n / 2;
            }

            //sb.Insert(0, "0", sb.Length % 4);
            //int count = 0;
            //for(int i = 0; i < sb.Length; i++)
            //{
            //    if (count % groupSize == 0)
            //    {
            //        sb.Insert(i, " ");
            //        i++;
            //    }
            //    count++;
            //}

            Console.WriteLine("Number: {0}, Binary: {1}", number, sb.ToString());
            return sb.ToString();
        }
    }
}
