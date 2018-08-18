using System;
using System.Collections;
using System.Collections.Generic; 

namespace Challenge
{
    public static class Utilities
    {
        public static void PrintList(List<int> a)
        {
            Console.Write("{ ");
            for(int i=0; i<a.Count;i++)
            {
                Console.Write(a[i]);
                if (i != a.Count-1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(" }");
        }

        public static void PrintList(List<string> a)
        {
            if (a == null)
            { return; }
            
            Console.Write("{ ");
            for(int i=0; i<a.Count;i++)
            {
                Console.Write(a[i]);
                if (i != a.Count-1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(" }");
        }

        public static void PrintMatrix<T>(T[,] m)
        {
            for(int i=0; i<m.GetLength(0); i++)
            {
                for(int j=0; j<m.GetLength(1); j++)
                {
                    Console.Write(m[i,j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}