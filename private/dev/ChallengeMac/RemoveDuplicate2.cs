// Given a sorted array, remove the duplicates in place such that each element can appear atmost twice and return the new length.
// Do not allocate extra space for another array, you must do this in place with constant memory.
// Note that even though we want you to return the new length, make sure to change the original array as well in place

// For example,
// Given input array A = [1,1,1,2],
// Your function should return length = 3, and A is now [1,1,2].

// Algo:
// 1. Iterate over the array
// 2. Keep a counter for count of the element
// 3. If the current element is the same as the last element, increment the counter
// 4. If counter > 2, keep iterating till the current element is not the same as previous one
// 5. Copy the different element into the index of repeating element
// 5. Return the original array

using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public static class ArrayWithDuplicate
{
    public static int RemoveThirdDuplicate(List<int> A)
    {
        int k = 0;
        int count = -1;
        int previous = A[0];
        for (int i = 0; i < A.Count; i++) {
            A[k] = A[i];
            if (previous == A[i]) 
            {
                count++;
            } 
            else 
            {
                count = 0;
            }
            previous = A[i];
            if (count < 2) 
            {
                k++;
            }
        }
        return k;        
    }

    public static void Test_RemoveThirdDuplicate()
    {
        List<int> a = new List<int> {1,1,1,2,4,4,4,5,5,5,6,6};
        int l = RemoveThirdDuplicate(a);
        Console.WriteLine("New length: " + l.ToString());
    }
}