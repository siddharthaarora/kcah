using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge
{
    public static class Matrix
    {
        public static void AntiDiagonal(int[,] A)
        {
            int size = Convert.ToInt32(Math.Sqrt(A.Length));

            for (int i=0; i<2*size-1;++i)
            {
                int offset = i < size ? 0 : i - size +1;
                for (int j = offset; j <=i - offset;++j)
                {
                    Console.Write(A[j,i-j]);
                }
                Console.WriteLine();
            }
        }
        public static void PrintMatrix(int[,] A)
        {
            for (int i=0;i<3;i++)
            {
                for (int j=0;j<3;j++)
                {
                    Console.Write(A[i,j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public static void Test_PrintAntiDiaglon()
        {
            int[,] A = new int[3,3];
            for (int i=0;i<3;i++)
            {
                for (int j=0;j<3;j++)
                {
                    A[i,j] = i+j;
                }
            }
            PrintMatrix(A);

            AntiDiagonal(A);
        }
    }
}