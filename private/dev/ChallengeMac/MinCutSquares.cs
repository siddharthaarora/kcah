// Given a paper of size A x B. Task is to cut the paper into squares of any size. 
// Find the minimum number of squares that can be cut from the paper.
// https://practice.geeksforgeeks.org/problems/min-cut-square/0

using System;

namespace Challenge
{
    public static class MinCutSquare
    {
        public static int FindMinimumNumberOfSquaresInRectangle(int x, int y)
        {
            int[,] m = new int[x+1,y+1];

            for(int i=0;i<=x;i++)
            {
                for(int j=0;j<=y;j++)
                {
                    Utilities.PrintMatrix(m);
                    Console.WriteLine("-------------------");
                    if (i==0 || j==0)
                    {
                        m[i,j] = 0;
                        continue;
                    }
                    if (i == j)
                    {
                        m[i,j] = 1;
                        continue;
                    }
                    if (x%y == 0)
                    {
                        m[i,j] = x/y;
                        continue;
                    }
                    if (y%x == 0)
                    {
                        m[i,j] = y/x;
                        continue;
                    }

                    int smaller = Math.Min(i,j);
                    int min = Int32.MaxValue;

                    for(int k=1;k<=smaller;k++)
                    {
                        int mink = Math.Min(m[i-k,j]+m[k,j-k],m[i,j-k]+m[i-k,k]);
                        min = Math.Min(min,mink);
                    }
                    m[i,j] = 1+min;
                }
            }

            Utilities.PrintMatrix(m);
            Console.WriteLine("-------------------");

            return m[x,y];
        }

        public static void Test_FindMinimumNumberOfSquaresInRectangle()
        {
            // int steps = int.Parse(Console.ReadLine());
            // for (int i = 0; i < steps; i++)
            // {
            //     string i1 = Console.ReadLine();
            //     string[] a1 = i1.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //     int x = Int32.Parse(a1[0]);
            //     int y = Int32.Parse(a1[1]);

            //     int minCutSquare = FindMinimumNumberOfSquaresInRectangle(x, y);

            //     Console.WriteLine(minCutSquare);
            // }
                int minCutSquare = FindMinimumNumberOfSquaresInRectangle
                                    (6,4);

                Console.WriteLine(minCutSquare);            
        }
    }

}