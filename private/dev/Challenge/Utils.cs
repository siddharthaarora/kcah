using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge
{
    public static class Utils
    {
        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }

            return true;
        }

        public static void PrintList(List<int> l)
        {
            for(int i=0;i<l.Count;i++)
            {
                Console.Write(l[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
            return;
        }

        // Reverse digits of an integer.
        // Example1: x = 123, return 321
        // Example2: x = -123, return -321
        // Return 0 if the result overflows and does not fit in a 32 bit signed integer
        public static int ReverseDigits(int n)
        {
            int temp = n, rn = 0;
            bool isNegative = false;
            
            if (temp < 0)
            {
                temp *= -1;
                isNegative = true;
            }

    
            while (temp > 0)
            {
                int lastDigit = temp % 10;

                if ((rn > Int32.MaxValue /10) || (rn == Int32.MaxValue / 10 && lastDigit > Int32.MaxValue % 10))
                { return 0; }

                rn = rn * 10 + lastDigit;
                temp /= 10;

            }
            if (isNegative) { rn = 1 - rn - 1; }

            return rn;
        }

        // Print Pascal's Triangle
        // public static void List<List<int>> GeneratePascalsTriangle(int A)
        // {
        //     List<List<int>> resultList = new List<List<int>>();
        //     List<int> rowList = new List<int>();

        //     if(A == 0) {
        //         return resultList;
        //     }
        //     rowList.Add(1);
        //     resultList.Add(rowList);
        //     if(A == 1) {
        //         return resultList;
        //     }
        //     for(int i = 1; i < A; i++) {
        //         rowList = new List<int>();
        //         for(int j = 0; j <= i; j++) {
        //             if(j==0 || j==i){
        //                 rowList.Add(1);
        //                 continue;
        //             }
        //             int numberLeftAbove = resultList[i - 1][j];
        //             int numberRightAbove = resultList[i - 1][j - 1];
        //             int num = numberLeftAbove + numberRightAbove;
        //             rowList.Add(num);
        //         }
        //         resultList.Add(rowList);
        //     }
        //     return resultList;
        // }
    }
}
