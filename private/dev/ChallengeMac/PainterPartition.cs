using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Challenge
{
    public static class PainterPartition
    {
        public static int FindMinimumTimeToPaintBoards(int numPainters, int numBoards, int[] a)
        {
            int sum = 0;
            int min = -1;
            
            for (int i=0;i<a.Length;i++)
            {
                sum += a[i];
                if (min == -1 || min < a[i])
                {
                    min = a[i];
                }
            }

            if (numPainters == 1)
            {
                return sum;
            }

            if(numPainters >= numBoards)
            {
                return min;
            }

            int t = 0;
            int tpp = sum / numPainters;

            for (int i=0;i<a.Length;i++)
            {
                if (t + a[i] >= tpp && a.Length-i >= numPainters)
                {
                    if (t + a[i] > min)
                    {
                        min = t + a[i];
                    }
                    t = 0;
                    continue;
                }
                else if (t < tpp && a.Length - i < numPainters)
                {
                    if (t > min)
                    {
                        min = t;
                    }
                    t = 0;
                    continue;
                }
                     
                t = t + a[i];
            }

            return min;
        }

        public static void Test_FindMinimumTimeToPaintBoards()
        {
            //int numBoards = 4;
            //int numPainters = 3;
            //int[] a = new int[] {10, 20, 30, 40};

            Console.WriteLine("Enter number of test cases");
            int steps = int.Parse(Console.ReadLine());
            for (int i = 0; i < steps; i++)
            {
                Console.WriteLine("Enter number of Painters and Boards, separated by a single space");
                string i1 = Console.ReadLine();
                string[] a1 = i1.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int numPainters = Int32.Parse(a1[0]);
                int numBoards = Int32.Parse(a1[1]);

                Console.WriteLine("Enter Board lengths, separated by a single space");
                string i2 = Console.ReadLine();
                string[] a2 = i2.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int[] a = new int[a2.Length];
                for (int j = 0; j < a2.Length; j++)
                { a[j] = Int32.Parse(a2[j]); }

                int minTimeToPaint = FindMinimumTimeToPaintBoards(numPainters, numBoards, a);

                Console.WriteLine("Number of Painters: " + numPainters.ToString() + "; number of Boards: " + numBoards.ToString() + "; Board lengths: " + i2.ToString());
                Console.WriteLine("Minimum time to paint this set of boards will be: " + minTimeToPaint.ToString());
            }
        }
    }
}