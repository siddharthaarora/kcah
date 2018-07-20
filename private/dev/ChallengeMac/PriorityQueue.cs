using System;
using System.Collections;
using System.Collections.Generic;

namespace Challenge
{
    public class PriorityQueue
    {
        private int[] queue = new int[10];
        private int minimum = 0;
        private int minimumIndex = 0;
        private int index = 0;

        public void Insert(int a)
        {
            if (index == queue.Length)
            {
                throw new Exception("Queue has reached it's capacity!");
            }
            queue[index] = a;
            if (minimum == 0)
            {
                minimum = a;
            }
            else if (a < minimum)
            {
                minimum = a;
                minimumIndex = index;
            }

            if (index+1 < queue.Length)
            {
                index++;
            }
        }

        public int FindMinimum()
        {
            return minimum;
        }

        public void DeleteMinimum()
        {
            minimum = Int32.MaxValue;
            queue[minimumIndex] = queue[index];
            queue[index] = Int32.MaxValue;

            for (int i=0; i<queue.Length;i++)
            {
                if (queue[i] < minimum)
                {
                    minimum = queue[i];
                    minimumIndex = i;
                }
            }
        }

        public static void Test_PriorityQueue()
        {
            List<int> a = new List<int>(){14, 16, 12, 27, 21, 43, 35, 19, 58, 88};
            PriorityQueue queue = new PriorityQueue();

            foreach(int n in a)
            {
                queue.Insert(n);
            }

            for (int i=0; i<a.Count;i++)
            {
                Console.WriteLine("Minimum: " + queue.FindMinimum().ToString());
                queue.DeleteMinimum();
            }
            
        }
    }
}