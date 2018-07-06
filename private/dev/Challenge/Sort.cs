using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge
{
    public class Sort
    {
        //Best and average - nLogn; Worst - n^2
        public static void QuickSort(int[] arr, int i, int j)
        {
            if (i < j)
            {
                int pos = Partition(arr, i, j);
                QuickSort(arr, i, pos - 1);
                QuickSort(arr, pos + 1, j);
            }
        }

        private static int Partition(int[] arr, int i, int j)
        {
            int pivot = arr[j];
            int small = i - 1;
            Console.WriteLine("Pivot = " + pivot);

            for (int k = i; k < j; k++)
            {
                if (arr[k] <= pivot)
                {
                    small++;
                    Swap(arr, k, small);
                    Console.WriteLine(String.Join(" ", arr));
                }
            }

            Swap(arr, j, small + 1);
            Console.WriteLine("Pivot = " + arr[small + 1]);
            Console.WriteLine(String.Join(" ", arr));
            return small + 1;
        }

        private static void Swap(int[] arr, int k, int small)
        {
            int temp;
            temp = arr[k];
            arr[k] = arr[small];
            arr[small] = temp;
        }

        public static void BubbleSort(List<int> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = 0; j < a.Count - i - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }

                // Print array after every pass
                Console.Write("After pass " + i + "  : ");
                //Printing array after pass
                Console.WriteLine(String.Join(" ", a));
            }
        }

        public static void MergeSort(List<int> a)
        { }

    }
}
