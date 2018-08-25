// Partition a set into two subsets such that the difference of subset sums is minimum
// Given a set of integers, the task is to divide it into two sets S1 and S2 such that 
// the absolute difference between their sums is minimum. 

// Input:  arr[] = {1, 6, 11, 5} 
// Output: 1
// Explanation:
// Subset1 = {1, 5, 6}, sum of Subset1 = 12 
// Subset2 = {11}, sum of Subset2 = 11  

using System;

namespace Challenge
{
    public static class SubsetPartition
    {
        public static int PartitionIntoSetsWithMinimumDifference(int[] a)
        {
            return PartitionIntoSetsWithMinimumDifference(a, a.Length);
        }

        private static int PartitionIntoSetsWithMinimumDifference(int[] a, int n)
        {
            if (n == 0)
            { return 0;}
            
            int sum = 0, diff = Int32.MaxValue;
            for(int i=0;i<n;i++)
            {
                sum += a[i];
            }

            int[,] t = new int[n+1,n+1];

            for(int i=0;i<n;i++)
            {
                for(int j=0;j<n;j++)
                {
                    if (i == 0)
                    {
                        t[i,j] = a[j];
                    }
                    else if (j == 0)
                    {
                        t[i,j] = a[j];
                    }
                    else
                    {
                        t[i,j] = (a[j] + t[i-1,j-1]);
                    }
                }
            }

            Utilities.PrintMatrix<int>(t);
            return diff;
        }

        public static void Test_PartitionIntoSetsWithMinimumDifference()
        {
            int diff = PartitionIntoSetsWithMinimumDifference(new int[]{1,2,5,6,3,11});
            Console.WriteLine("Minimum diff for set is: " + diff.ToString());
        }
    }
}