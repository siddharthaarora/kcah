using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sid.HackerRank
{
    class Solution1 {

        static void Main(String[] args) {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp,Int32.Parse);
        }
        
        //{1, 2, 3, 4, 5} --2--> {3, 4, 5, 1, 2}
//         static void RotateArrayLeft()
//         {
//             // if the n == k, then no rotation is required
//             if (n == k || k <= 0)
//             {return;}

//             if (k > n)
//             {
//                 k = k % n;
//             }

//             PrintArray();

//             int temp;
//             for(int i=n-1; i--; i=n)
//             {
//                 temp = a[i];
//                 a[i] = a[n-k];
//                 a[n-k] = temp;
//                 PrintArray();
//             }
//         }

//         static void PrintArray()
//         {
//             Console.Write("{");
//             foreach (var item in a)
//             {
//                 Console.Write(item + ", "); 
//             }
//             Console.Write("{");
//         }
     }
}