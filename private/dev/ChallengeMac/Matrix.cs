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

        //Given a boolean 2D matrix, find the number of islands.A group of connected 1s forms an island.For example, the below matrix contains 5 islands
        //Example:
        //Input : mat[][] = {
        //           { 1, 1, 0, 0, 0},
        //           { 0, 1, 0, 0, 1},
        //           { 1, 0, 0, 1, 1},
        //           { 0, 0, 0, 0, 0},
        //           { 1, 0, 1, 0, 1}
        //         }
        //Output: 5
        //   
        public static int FindNumberOfIslands(int?[,] A)
        {
            int count = 0;

            int rows = A.GetLength(0);
            int cols = A.GetLength(1);

            bool[,] visited = new bool[rows, cols];
            
            for(int i=0;i<rows;i++)
            {
                for(int j=0;j<cols;j++)
                {
                    if ((A[i,j] == 1) && !visited[i,j])
                    {
                        DepthFirstSearch(A, i, j, rows, cols, visited);
                        count++;
                    }
                }
            }

            return count;
        }

        private static void DepthFirstSearch(int?[,] matrix, int r, int c, int rows, int cols, bool[,] visited)
        {
            int[] rowNbr = new int[] {-1, -1, -1, 0,
                                   0, 1, 1, 1};
            int[] colNbr = new int[] {-1, 0, 1, -1,
                                   1, -1, 0, 1};

            if (r == c)
            { return; }

            visited[r, c] = true;

            for(int i=0;i<8;i++)
            {
                if (IsValidMatrixElement(r+rowNbr[i], c+colNbr[i], rows, cols, matrix, visited))
                {
                    DepthFirstSearch(matrix, r + rowNbr[i], c + colNbr[i], rows, cols, visited);
                }
            }

        }

        private static bool IsValidMatrixElement(int r, int c, int rows, int cols, int?[,] matrix, bool[,] visited)
        {
            if ((r >=0 && r < rows) && 
                (c >= 0 && c < cols) && 
                matrix[r,c] == 1 &&
                !visited[r,c])
            { return true; }
            else
            { return false; }
        }

        public static void Test_FindNumberOfIslands()
        {
            var graph = Graph.CreateSampleGraph();
            int?[,] matrix = graph.CreateAdjacencyMatrix();

            graph.PrintAdjacencyMatrix(matrix);

            int count = FindNumberOfIslands(matrix);

            Console.WriteLine("Number of islands: " + count.ToString());
        }
    }

}