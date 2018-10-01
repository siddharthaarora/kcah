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

            for(int i=0;i<a.Length;i++)
            {
                if (t+a[i] > sum/numPainters)
                {
                    if (t+a[i] > min)
                    {
                        min = t+a[i];
                    }
                    t = 0;
                    continue;
                }
                t+= a[i];
            }

            return min;
        }

        public static void Test_FindMinimumTimeToPaintBoards()
        {
            int numBoards = 4;
            int numPainters = 2;
            int[] a = new int[] {10, 10, 10, 10};

            int minTimeToPaint = FindMinimumTimeToPaintBoards(numPainters, numBoards, a);

            Console.WriteLine("Minimum time to paint this room will be: " + minTimeToPaint.ToString());
        }
    }
}